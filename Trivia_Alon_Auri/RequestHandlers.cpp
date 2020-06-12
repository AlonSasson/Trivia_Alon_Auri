#include "RequestHandlers.h"
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
	CREATE_ROOM
};

// logs in a user 
RequestResult LoginRequestHandler::login(RequestInfo request)
{
	RequestResult loginResult;
	LoginResponse response; 
	LoginRequest loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(request.buffer);

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
	GetPlayersInRoomResponse respone;
	GetPlayersInRoomRequest getPlayersInRoomRequest = JsonRequestPacketDeserializer::deserializeGetPlayersInRoomRequest(request.buffer);
	respone.players = (RoomManager::getInstance()).getRoom(request.id).getAllUsers();

	getPlayersInRoomResult.response = JsonResponsePacketSerializer::serializeGetPlayersInRoomResponse(respone);

	getPlayersInRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	
	return getPlayersInRoomResult;
	
}

RequestResult MenuRequestHandler::getStatistics(RequestInfo request)
{
	RequestResult getStatisticsResult;
	getStaticsResponse response;
	HighscoreRequest highscoreRequest = JsonRequestPacketDeserializer::deserializeHighScoreRequest(request.buffer);
	
	response.highScores = m_handlerFactory.getStatisticsManager().getTopPlayers();
	response.statics = m_handlerFactory.getStatisticsManager().getUserStats(highscoreRequest.username);
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

	if (response.status == RoomManager::ROOM_WHILE_GAME || response.status == RoomManager::ROOM_GAME_ENDED)
	{
		joinRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state
	}
	else
	{
		joinRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // move on to next state
	}
	return joinRoomResult;

}

RequestResult MenuRequestHandler::createRoom(RequestInfo request)
{
	RequestResult createRoomResult;
	CreateRoomResponse response;
	CreateRoomRequest createRoomRequest = JsonRequestPacketDeserializer::deserializeCreateRoomRequest(request.buffer);
	RoomData roomData = { RoomManager::getInstance().getNextRoomId(), createRoomRequest.roomName, createRoomRequest.maxUsers, createRoomRequest.answerTimeout, (unsigned int)RoomManager::ROOM_WAITING_FOR_PLAYERS};
	response.status = (RoomManager::getInstance()).createRoom(m_user, roomData);

	if (response.status == OK)
		createRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // move on to next state
	else
		createRoomResult.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // stay in the same state
	return createRoomResult;
}

MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory , LoggedUser user):
	m_handlerFactory(handlerFactory), m_user(user)
{
}
