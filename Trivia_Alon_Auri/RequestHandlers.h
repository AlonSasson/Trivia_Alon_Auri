#pragma once
#include "Requests.h"
#include <ctime>
#include "RequestHandlerFactory.h"
#include <iostream>
#include "LoggedUser.h"
#include "RoomManager.h"
#include "StatisticsManager.h"
#include "Game.h"


class IRequestHandler;
typedef struct RequestResult
{
	unsigned char* response;
	IRequestHandler* newHandler;
}RequestResult;

class IRequestHandler
{
public:
	virtual void quitEarly() = 0;
	virtual bool isRequestRelevant(RequestInfo request) = 0;
	virtual RequestResult handleRequest(RequestInfo request) = 0;
};

class RequestHandlerFactory;
class LoginRequestHandler : public IRequestHandler
{
private:
	RequestHandlerFactory& m_handlerFactory;
	RequestResult login(RequestInfo request);
	RequestResult signup(RequestInfo request);
public:
	void quitEarly();
	LoginRequestHandler(RequestHandlerFactory& handlerFactory);
	bool isRequestRelevant(RequestInfo request);
	RequestResult handleRequest(RequestInfo request);
};

class RequestHandlerFactory;
class MenuRequestHandler : public IRequestHandler
{
private:
	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;

public:
	void quitEarly();
	MenuRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser user);
	bool isRequestRelevant(RequestInfo request);
	RequestResult handleRequest(RequestInfo request);
	RequestResult signout(RequestInfo request);
	RequestResult getRooms(RequestInfo request);
	RequestResult getPlayersInRoom(RequestInfo request);
	RequestResult getStatistics(RequestInfo request);
	RequestResult joinRoom(RequestInfo request);
	RequestResult createRoom(RequestInfo request);
	std::string getUser();
};

class RequestHandlerFactory;
class RoomAdminRequestHandler : public IRequestHandler
{
private:
	Room m_room;
	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;

public:
	void quitEarly();
	RoomAdminRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser m_user, int id);
	bool isRequestRelevant(RequestInfo request);
	RequestResult handleRequest(RequestInfo request);
	RequestResult closeRoom(RequestInfo request);
	RequestResult startGame(RequestInfo request);
	RequestResult getRoomState(RequestInfo request);

};

class RequestHandlerFactory;
class RoomMemberRequestHandler : public IRequestHandler
{
private:
	Room m_room;
	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;

public:
	void quitEarly();
	RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser m_user, int id);
	bool isRequestRelevant(RequestInfo request);
	RequestResult handleRequest(RequestInfo request);
	RequestResult leaveRoom(RequestInfo request);
	RequestResult startGame(RequestInfo request);
	RequestResult getRoomState(RequestInfo request);
};
class RequestHandlerFactory;
class GameRequestHandler : public IRequestHandler
{
private:
	Game& m_game;
	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;
	clock_t m_packetSendTime;
public:
	void quitEarly();
	GameRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser m_user, Game& game, clock_t time);
	bool isRequestRelevant(RequestInfo request);
	RequestResult handleRequest(RequestInfo request);
	RequestResult getQuestion(RequestInfo);
	RequestResult submitAnswer(RequestInfo);
	RequestResult getGameResults(RequestInfo);
	RequestResult leaveGame(RequestInfo);
};