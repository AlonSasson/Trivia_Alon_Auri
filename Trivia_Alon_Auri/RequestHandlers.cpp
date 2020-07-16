#include "RequestHandlers.h"
#include "Communicator.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

#define ERROR 0
#define OK 1

enum codeId
{
	LOGOUT = 0,
	SIGNUP,
	LOGIN,
	GET_ROOMS,
	GET_PLAYERS_IN_ROOM,
	GET_STATISTICS,
	JOIN_ROOM,
	CREATE_ROOM,
	CLOSE_ROOM,
	START_GAME,
	GET_ROOM_STATE,
	LEAVE_ROOM,
	LEAVE_GAME,
	GET_QUESTION,
	SUBMIT_ANSWER,
	GET_GAME_RESULTS
};

// logs in a user 
RequestResult LoginRequestHandler::login(RequestInfo request)
{
	RequestResult loginResult;
	LoginResponse response;
	LoginRequest loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(request.buffer);

	if (Communicator::m_users.find(loginRequest.username) == Communicator::m_users.end()) // if the user shouldn't be connected
		m_handlerFactory.getLoginManager().logout(loginRequest.username); // make sure they get logged out
	response.status = m_handlerFactory.getLoginManager().login(loginRequest.username, loginRequest.password); // get status from login into database
	loginResult.response = JsonResponsePacketSerializer::serializeResponse(response);

	if (response.status == OK)
		loginResult.newHandler = m_handlerFactory.createMenuRequestHandler(loginRequest.username); // move on to next state
	else
		loginResult.newHandler = m_handlerFactory.createLoginRequestHandler(); // stay in the same state
	return loginResult;
}

// signs up a user
RequestResult LoginRequestHandler::signup(RequestInfo request)
{
	RequestResult signupResult;
	SignupResponse response;
	SignupRequest signupRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(request.buffer);

	response.status = m_handlerFactory.getLoginManager().signup(signupRequest.username, signupRequest.password, signupRequest.email,
		signupRequest.address, signupRequest.phoneNumber, signupRequest.birthDate); // get status from signup into database
	signupResult.response = JsonResponsePacketSerializer::serializeResponse(response);

	if (response.status == OK)
		signupResult.newHandler = m_handlerFactory.createMenuRequestHandler(signupRequest.username); // move on to next state
	else
		signupResult.newHandler = m_handlerFactory.createLoginRequestHandler(); // stay in the same state
	return signupResult;
}

/*
check if the request is relevant - the id of the request much to the login id
*/
bool LoginRequestHandler::isRequestRelevant(RequestInfo request)
{
	return request.id == LOGIN || request.id == SIGNUP;
}
/*
handle the login request from client
*/
RequestResult LoginRequestHandler::handleRequest(RequestInfo request)
{
	RequestResult packetToReturn;

	if (isRequestRelevant(request))
	{
		if (request.id == LOGIN)
		{
			packetToReturn = login(request);
		}
		else if (request.id == SIGNUP)
		{
			packetToReturn = signup(request);
		}
	}
	else
	{
		ErrorResponse response;
		response.message = "Error, couldn't read request";
		packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(response);
		packetToReturn.newHandler = this->m_handlerFactory.createLoginRequestHandler(); // stay in the same state
	}
	return packetToReturn;
}

void LoginRequestHandler::quitEarly()
{
}

LoginRequestHandler::LoginRequestHandler(RequestHandlerFactory& handlerFactory) :
	m_handlerFactory(handlerFactory)
{
}

/*
check if the request relevant
*/
bool MenuRequestHandler::isRequestRelevant(RequestInfo request)
{
	return request.id == LOGOUT || request.id == GET_ROOMS || request.id == GET_PLAYERS_IN_ROOM ||
		request.id == GET_STATISTICS || request.id == JOIN_ROOM || request.id == CREATE_ROOM;
}

RequestResult MenuRequestHandler::handleRequest(RequestInfo request)
{

	RequestResult packetToReturn;
	if (isRequestRelevant(request))
	{
		switch (request.id)
		{
		case LOGOUT:
			packetToReturn = signout(request);
			break;
		case GET_ROOMS:
			packetToReturn = getRooms(request);
			break;
		case GET_PLAYERS_IN_ROOM:
			packetToReturn = getPlayersInRoom(request);
			break;
		case GET_STATISTICS:
			packetToReturn = getStatistics(request);
			break;
		case JOIN_ROOM:
			packetToReturn = joinRoom(request);
			break;
		case CREATE_ROOM:
			packetToReturn = createRoom(request);
			break;
		}
	}
	else
	{
		ErrorResponse response;
		response.message = "Error, couldn't read request";
		packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(response);
		packetToReturn.newHandler = this->m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state
	}
	return packetToReturn;
}

RequestResult MenuRequestHandler::signout(RequestInfo request)
{
	RequestResult logoutResult;
	LogoutResponse response;
	response.status = m_handlerFactory.getLoginManager().logout(m_user.getUserName());

	logoutResult.response = JsonResponsePacketSerializer::serializeLogoutResponse(response);

	if (response.status == OK)
		logoutResult.newHandler = m_handlerFactory.createLoginRequestHandler(); // go back to login state
	else
		logoutResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state
	return logoutResult;
}

RequestResult MenuRequestHandler::getRooms(RequestInfo request)
{
	RequestResult getRoomsResult;
	GetRoomsResponse response;

	response.rooms = (RoomManager::getInstance()).getRooms();
	if (response.rooms.size() == 0) // if there are no rooms
		response.status = ERROR;
	else
		response.status = OK;

	getRoomsResult.response = JsonResponsePacketSerializer::serializeGetRoomResponse(response);


	if (response.status == OK)
		getRoomsResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // move on to next state
	else
		getRoomsResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state


	return getRoomsResult;
}
RequestResult MenuRequestHandler::getPlayersInRoom(RequestInfo request)
{
	RequestResult getPlayersInRoomResult;
	GetPlayersInRoomResponse response;

	GetPlayersInRoomRequest getPlayersInRoomRequest = JsonRequestPacketDeserializer::deserializeGetPlayersInRoomRequest(request.buffer);
	response.players = (RoomManager::getInstance()).getRoom(getPlayersInRoomRequest.roomId).getAllUsers();

	getPlayersInRoomResult.response = JsonResponsePacketSerializer::serializeGetPlayersInRoomResponse(response);

	getPlayersInRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);


	return getPlayersInRoomResult;

}

RequestResult MenuRequestHandler::getStatistics(RequestInfo request)
{
	RequestResult getStatisticsResult;
	getStaticsResponse response;

	response.highScores = m_handlerFactory.getStatisticsManager().getTopPlayers();
	response.statics = m_handlerFactory.getStatisticsManager().getUserStats(m_user.getUserName());
	response.status = OK;
	getStatisticsResult.response = JsonResponsePacketSerializer::serializeHighScoreResponse(response);

	if (response.status == OK)
		getStatisticsResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // move on to next state
	else
		getStatisticsResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state
	return getStatisticsResult;
}

RequestResult MenuRequestHandler::joinRoom(RequestInfo request)
{
	RequestResult joinRoomResult;
	JoinRoomResponse response;

	JoinRoomRequest joinRoomRequest = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(request.buffer);
	response.status = (RoomManager::getInstance()).getRoomState(joinRoomRequest.roomId);

	if (response.status == Room::ROOM_WHILE_GAME || response.status == Room::ROOM_GAME_ENDED) 
	{
		joinRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state
	}
	else if (m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomId).getAllUsers().size() == m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomId).getRoomData().maxPlayers) // if the room is full
	{
		response.status = Room::ROOM_FULL;
		joinRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state
	}
	else // if the room is waiting
	{
		m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomId).addUser(m_user);
		joinRoomResult.newHandler = m_handlerFactory.createRoomMemberRequestHanlder(m_user, m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomId)); // move on to next state
	}
	joinRoomResult.response = JsonResponsePacketSerializer::serializeJoinRoomResponse(response);

	return joinRoomResult;

}

RequestResult MenuRequestHandler::createRoom(RequestInfo request)
{
	RequestResult createRoomResult;
	CreateRoomResponse response;
	CreateRoomRequest createRoomRequest = JsonRequestPacketDeserializer::deserializeCreateRoomRequest(request.buffer);

	response.status = OK;
	int id = RoomManager::getInstance().getNextRoomId();
	RoomData roomData = { id , createRoomRequest.roomName, createRoomRequest.maxUsers, createRoomRequest.answerTimeout, (unsigned int)Room::ROOM_WAITING_FOR_PLAYERS };
	if (!(RoomManager::getInstance()).createRoom(m_user, roomData))
	{
		response.status = ERROR;
	}
	createRoomResult.response = JsonResponsePacketSerializer::serializeCreateRoomResponse(response);

	if (response.status == OK)
		createRoomResult.newHandler = m_handlerFactory.createRoomAdminRequestHanlder(m_user, m_handlerFactory.getRoomManager().getRoom(id)); // move on to next state
	else
		createRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state
	return createRoomResult;
}

void MenuRequestHandler::quitEarly()
{
	this->m_handlerFactory.getLoginManager().logout(m_user.getUserName());

}

MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser user) :
	m_handlerFactory(handlerFactory), m_user(user)
{
}
void RoomAdminRequestHandler::quitEarly()
{
	this->m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).removeUser(m_user);
	m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).setRoomState(Room::RoomState::ROOM_GAME_ENDED);
	if (m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).getAllUsers().size() == 0)
	{
		m_handlerFactory.getRoomManager().deleteRoom(m_room.getRoomData().id);
	}
	this->m_handlerFactory.getLoginManager().logout(m_user.getUserName());

}
RoomAdminRequestHandler::RoomAdminRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser m_user, int id)
	: m_handlerFactory(handlerFactory), m_user(m_user), m_room(handlerFactory.getRoomManager().getRoom(id))
{
}
/*
	check if request is relevant
*/
bool RoomAdminRequestHandler::isRequestRelevant(RequestInfo request)
{
	return request.id == CLOSE_ROOM || request.id == START_GAME || request.id == GET_ROOM_STATE;
}

RequestResult RoomAdminRequestHandler::handleRequest(RequestInfo request)
{
	RequestResult packetToReturn;

	if (isRequestRelevant(request))
	{
		switch (request.id)
		{
		case CLOSE_ROOM:
			packetToReturn = closeRoom(request);
			break;
		case START_GAME:
			packetToReturn = startGame(request);
			break;
		case GET_ROOM_STATE:
			packetToReturn = getRoomState(request);
			break;
		}
	}
	else
	{
		ErrorResponse e;
		e.message = "ERROR";
		packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(e);
		packetToReturn.newHandler = m_handlerFactory.createRoomAdminRequestHanlder(this->m_user, this->m_room);
	}
	return packetToReturn;
}

RequestResult RoomAdminRequestHandler::closeRoom(RequestInfo request)
{
	RequestResult closeRoomResult;
	CloseRoomResponse response;
	response.status = OK;

	if (!m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).removeUser(m_user))
	{
		response.status = ERROR;
	}
	else
	{
		m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).setRoomState(Room::RoomState::ROOM_GAME_ENDED);
	}

	if (m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).getAllUsers().size() == 0)
	{
		m_handlerFactory.getRoomManager().deleteRoom(m_room.getRoomData().id);
	}
	closeRoomResult.response = JsonResponsePacketSerializer::serializeCloseRoomResponse(response);

	if (response.status == OK)
		closeRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // move on to next state
	else
		closeRoomResult.newHandler = m_handlerFactory.createRoomAdminRequestHanlder(m_user, m_room); // stay in the same state
	return closeRoomResult;
}

RequestResult RoomAdminRequestHandler::startGame(RequestInfo request)
{
	RequestResult startGameResult;
	StartGameResponse response;
	response.status = OK;

		m_handlerFactory.getGameManager().createGame(this->m_room);
	try
	{
		Game& game = m_handlerFactory.getGameManager().getGameForPlayer(this->m_user.getUserName());
		m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).setRoomState(Room::ROOM_WHILE_GAME);
		startGameResult.newHandler = m_handlerFactory.createGameRequestHandler(game, this->m_user, 0); // move to next state
	}
	catch (std::exception& e) // if no game has been found
	{
		response.status = ERROR;
	}
	if (!m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).removeUser(m_user)) // if removing the user failed
		response.status = ERROR;
	if (m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).getAllUsers().size() == 0) // if no users are left in the room
		m_handlerFactory.getRoomManager().deleteRoom(m_room.getRoomData().id);

	if (response.status == ERROR)
		startGameResult.newHandler = m_handlerFactory.createRoomAdminRequestHanlder(this->m_user, this->m_room); // stay in same state

	startGameResult.response = JsonResponsePacketSerializer::serializeStartGameResponse(response);

	return startGameResult;
}

RequestResult RoomAdminRequestHandler::getRoomState(RequestInfo request)
{
	RequestResult getRoomStateResult;
	GetRoomStateResponse response;
	static int i = 1;
	response.answerTimeout = m_room.getRoomData().timePerQuestion;
	response.hasGameBegun = m_room.getRoomData().isActive;
	response.players = m_room.getAllUsers();

	i++;
	response.questionCount = 10;
	response.status = OK;

	getRoomStateResult.response = JsonResponsePacketSerializer::serializeGetRoomStateResponse(response);

	getRoomStateResult.newHandler = m_handlerFactory.createRoomAdminRequestHanlder(this->m_user, this->m_room);

	return getRoomStateResult;

}

std::string MenuRequestHandler::getUser()
{
	return this->m_user.getUserName();
}

void RoomMemberRequestHandler::quitEarly()
{
	this->m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).removeUser(m_user);
	if (m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).getAllUsers().size() == 0)
	{
		m_handlerFactory.getRoomManager().deleteRoom(m_room.getRoomData().id);
	}
	this->m_handlerFactory.getLoginManager().logout(m_user.getUserName());
}

RoomMemberRequestHandler::RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser m_user, int id)
	: m_handlerFactory(handlerFactory), m_user(m_user), m_room(handlerFactory.getRoomManager().getRoom(id))
{
}

bool RoomMemberRequestHandler::isRequestRelevant(RequestInfo request)
{
	return request.id == LEAVE_ROOM || request.id == START_GAME || request.id == GET_ROOM_STATE;
}

RequestResult RoomMemberRequestHandler::handleRequest(RequestInfo request)
{
	RequestResult packetToReturn;

	if (isRequestRelevant(request))
	{
		switch (request.id)
		{
		case LEAVE_ROOM:
			packetToReturn = leaveRoom(request);
			break;
		case START_GAME:
			packetToReturn = startGame(request);
			break;
		case GET_ROOM_STATE:
			packetToReturn = getRoomState(request);
			break;
		}
	}
	else
	{
		ErrorResponse e;
		e.message = "ERROR";
		packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(e);
		packetToReturn.newHandler = m_handlerFactory.createRoomMemberRequestHanlder(this->m_user, this->m_room);
	}
	return packetToReturn;
}

RequestResult RoomMemberRequestHandler::leaveRoom(RequestInfo request)
{
	RequestResult leaveRoomResult;
	LeaveRoomResponse response;
	response.status = OK;

	if (!m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).removeUser(m_user) || !this->m_handlerFactory.getRoomManager().doesRoomExist(m_room.getRoomData().name))
	{
		response.status = ERROR;
	}
	if (m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).getAllUsers().size() == 0)
	{
		m_handlerFactory.getRoomManager().deleteRoom(m_room.getRoomData().id);
	}
	leaveRoomResult.response = JsonResponsePacketSerializer::serializeLeaveRoomResponse(response);


	leaveRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);

	return leaveRoomResult;

}

RequestResult RoomMemberRequestHandler::startGame(RequestInfo request)
{
	RequestResult startGameResult;
	StartGameResponse response;

	response.status = OK;
	try
	{
		Game& game = m_handlerFactory.getGameManager().getGameForPlayer(this->m_user.getUserName());
		startGameResult.newHandler = m_handlerFactory.createGameRequestHandler(game, this->m_user, 0); // move to next state
	}
	catch (std::exception& e) // if no game has been found
	{
		response.status = ERROR;
	}
	if (!m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).removeUser(m_user)) // if removing the user failed
		response.status = ERROR;
	if (m_handlerFactory.getRoomManager().getRoom(m_room.getRoomData().id).getAllUsers().size() == 0) // if no users are left in the room
		m_handlerFactory.getRoomManager().deleteRoom(m_room.getRoomData().id);

	if (response.status == ERROR)
		startGameResult.newHandler = m_handlerFactory.createRoomMemberRequestHanlder(this->m_user, this->m_room); // stay in same state

	startGameResult.response = JsonResponsePacketSerializer::serializeStartGameResponse(response);

	return startGameResult;
}

RequestResult RoomMemberRequestHandler::getRoomState(RequestInfo request)
{
	RequestResult getRoomStateResult;
	GetRoomStateResponse response;

	response.answerTimeout = m_room.getRoomData().timePerQuestion;
	response.hasGameBegun = m_room.getRoomData().isActive;
	response.players = m_room.getAllUsers();
	response.questionCount = 10;
	response.status = OK;

	getRoomStateResult.response = JsonResponsePacketSerializer::serializeGetRoomStateResponse(response);

	getRoomStateResult.newHandler = m_handlerFactory.createRoomMemberRequestHanlder(this->m_user, this->m_room);

	return getRoomStateResult;
}

void GameRequestHandler::quitEarly()
{
	this->m_handlerFactory.getGameManager().removePlayerInGame(m_user, m_game);
	if (m_game.playersInGame() == 0) // if the game is empty
	{
		m_handlerFactory.getGameManager().deleteGame(m_game);
	}
	this->m_handlerFactory.getLoginManager().logout(m_user.getUserName());
}

GameRequestHandler::GameRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser m_user, Game& game, clock_t time)
	: m_game(game), m_user(m_user), m_handlerFactory(handlerFactory) , m_packetSendTime(time)
{
}

bool GameRequestHandler::isRequestRelevant(RequestInfo request)
{
	return 	request.id == LEAVE_GAME || request.id == GET_QUESTION || request.id == SUBMIT_ANSWER || request.id == GET_GAME_RESULTS;
}

RequestResult GameRequestHandler::handleRequest(RequestInfo request)
{
	RequestResult packetToReturn;

	if (isRequestRelevant(request))
	{
		switch (request.id)
		{
		case LEAVE_GAME:
			packetToReturn = leaveGame(request);
			break;
		case GET_QUESTION:
			packetToReturn = getQuestion(request);
			break;
		case SUBMIT_ANSWER:
			packetToReturn = submitAnswer(request);
			break;
		case GET_GAME_RESULTS:
			packetToReturn = getGameResults(request);
			break;
		}
	}
	else
	{
		ErrorResponse e;
		e.message = "ERROR";
		packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(e);
		packetToReturn.newHandler = m_handlerFactory.createGameRequestHandler(this->m_game, this->m_user, this->m_packetSendTime);
	}
	return packetToReturn;
}

RequestResult GameRequestHandler::getQuestion(RequestInfo request)
{
	RequestResult getQuestionResult;
	GetQestionResponse response;
	Question question;
	std::vector<std::string> answers;
	response.status = OK;
	question = this->m_game.getQuestionForUser(this->m_user);
	response.question = question.getQuestion();
	if (question.getQuestion() == "") // if there are no question left
	{
		response.status = ERROR;
		response.answers = std::map<unsigned int, std::string>();
	}
	else // if there was a valid question
	{
		answers = question.getPossibleAnswers();
		for (int i = 0; i < answers.size(); i++) // add the answers
			response.answers.insert(std::pair<unsigned int, std::string>(i + 1, answers[i]));
	}

	getQuestionResult.response = JsonResponsePacketSerializer::serializeGetQuestionResponse(response);
	this->m_packetSendTime = clock();

	getQuestionResult.newHandler = m_handlerFactory.createGameRequestHandler(this->m_game, this->m_user, this->m_packetSendTime); // stay in same handler
	return getQuestionResult;
}

RequestResult GameRequestHandler::submitAnswer(RequestInfo request)
{
	RequestResult submitAnswerResult;
	SubmitAnswerResponse response;
	SubmitAnswerReqest submitAnswerReqest;
	response.status = OK;
	response.correctAnswerId = 0;
	submitAnswerReqest = JsonRequestPacketDeserializer::deserializerSubmitAnswerRequest(request.buffer);

	clock_t time = request.receivalTime -this->m_packetSendTime;

	response.correctAnswerId = m_game.submitAnswer(m_user, submitAnswerReqest.answerId, ((double)time) / CLOCKS_PER_SEC);
	submitAnswerResult.response = JsonResponsePacketSerializer::serializeGetSubmitAnswerResponse(response);

	submitAnswerResult.newHandler = m_handlerFactory.createGameRequestHandler(m_game, m_user, this->m_packetSendTime); // stay in the same state

	return submitAnswerResult;
}

RequestResult GameRequestHandler::getGameResults(RequestInfo request)
{
	static int waitForResults = 0;
	waitForResults++;
	RequestResult getGameResults;
	GetGameResultResponse response;

	response.status = OK;

	while (waitForResults != m_game.playersInGame());
	response.results = m_game.getGameResults();
	getGameResults.response = JsonResponsePacketSerializer::serializeGetGameResultsResponse(response);

	getGameResults.newHandler = m_handlerFactory.createGameRequestHandler(m_game, m_user, this->m_packetSendTime);
	waitForResults = 0;
	return getGameResults;
}

RequestResult GameRequestHandler::leaveGame(RequestInfo request)
{
	RequestResult leaveGameResult;
	LeaveGameResponse response;
	response.status = OK;

	m_handlerFactory.getGameManager().removePlayerInGame(this->m_user, this->m_game);
	if (m_game.playersInGame() == 0) // if the game is empty
	{
		m_handlerFactory.getGameManager().deleteGame(m_game);
	}
	leaveGameResult.response = JsonResponsePacketSerializer::serializeLeaveGameResponse(response);

	leaveGameResult.newHandler = m_handlerFactory.createMenuRequestHandler(this->m_user); // go back to room menu

	return leaveGameResult;
}
