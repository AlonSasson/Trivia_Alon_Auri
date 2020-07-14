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
	LEAVE_ROOM
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
		signupResult.newHandler =m_handlerFactory.createLoginRequestHandler(); // stay in the same state
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
		else if(request.id == SIGNUP)
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

LoginRequestHandler::LoginRequestHandler(RequestHandlerFactory& handlerFactory):
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
	joinRoomResult.response = JsonResponsePacketSerializer::serializeJoinRoomResponse(response);

	if (response.status == Room::ROOM_WHILE_GAME || response.status == Room::ROOM_GAME_ENDED)
	{
		joinRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // move on to next state
	}
	else
	{
		m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomId).addUser(m_user);
		joinRoomResult.newHandler = m_handlerFactory.createRoomMemberRequestHanlder(m_user, m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomId)); // stay in the same state
	}
	return joinRoomResult;

}

RequestResult MenuRequestHandler::createRoom(RequestInfo request)
{
	RequestResult createRoomResult;
	CreateRoomResponse response;
	CreateRoomRequest createRoomRequest = JsonRequestPacketDeserializer::deserializeCreateRoomRequest(request.buffer);
	
	response.status = OK;
	int id = RoomManager::getInstance().getNextRoomId();
	RoomData roomData = { id , createRoomRequest.roomName, createRoomRequest.maxUsers, createRoomRequest.answerTimeout, (unsigned int)Room::ROOM_WAITING_FOR_PLAYERS};
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

MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory , LoggedUser user):
	m_handlerFactory(handlerFactory), m_user(user)
{
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
		packetToReturn.newHandler = new RoomAdminRequestHandler(this->m_handlerFactory, this->m_user, this->m_room.getRoomData().id);
	}
	return packetToReturn;
}

RequestResult RoomAdminRequestHandler::closeRoom(RequestInfo request)
{
	RequestResult closeRoomResult;
	CloseRoomResponse response;
	RequestInfo requestInfo;
	response.status = OK;
	requestInfo.id = LEAVE_ROOM;
	requestInfo.receivalTime = 0;


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
		closeRoomResult.newHandler = m_handlerFactory.createRoomAdminRequestHanlder(m_user ,m_room); // stay in the same state
	return closeRoomResult;
}

RequestResult RoomAdminRequestHandler::startGame(RequestInfo request)
{
	RequestResult startGameResult;
	StartGameResponse response;
	RequestInfo requestInfo;
	
	response.status = OK;
	requestInfo.id = START_GAME;
	requestInfo.receivalTime = 0;



	startGameResult.response = JsonResponsePacketSerializer::serializeStartGameResponse(response);

	startGameResult.newHandler = m_handlerFactory.createRoomAdminRequestHanlder(m_user, m_room);

	m_room.setRoomState(Room::ROOM_WHILE_GAME);

	startGameResult.newHandler = new RoomAdminRequestHandler(this->m_handlerFactory, this->m_user, this->m_room.getRoomData().id);

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

	getRoomStateResult.newHandler = new RoomAdminRequestHandler(this->m_handlerFactory, this->m_user, this->m_room.getRoomData().id);

	return getRoomStateResult;

}

std::string MenuRequestHandler::getUser()
{
	return this->m_user.getUserName();
}

RoomMemberRequestHandler::RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser m_user,int id)
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
		packetToReturn.newHandler = new RoomMemberRequestHandler(this->m_handlerFactory, this->m_user, this->m_room.getRoomData().id);
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
	startGameResult.response = JsonResponsePacketSerializer::serializeStartGameResponse(response);

	startGameResult.newHandler = new RoomMemberRequestHandler(this->m_handlerFactory, this->m_user, this->m_room.getRoomData().id);;
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
	std::cout << response.hasGameBegun;
	getRoomStateResult.response = JsonResponsePacketSerializer::serializeGetRoomStateResponse(response);

	getRoomStateResult.newHandler = new RoomMemberRequestHandler(this->m_handlerFactory, this->m_user, this->m_room.getRoomData().id);;

	return getRoomStateResult;
}

