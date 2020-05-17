#pragma once
#include "Requests.h"
#include <ctime>
#include "RequestHandlerFactory.h"
#include <iostream>

class IRequestHandler;
typedef struct RequestResult
{
	unsigned char* response;
	IRequestHandler* newHandler;
}RequestResult;

class IRequestHandler
{
public:
	virtual bool isRequestRelevant(RequestInfo request) = 0;
	virtual RequestResult handleRequest(RequestInfo request) = 0;
};

class RequestHandlerFactory;
class LoginRequestHandler : public IRequestHandler
{
private:
	LoginManager& m_loginManager;
	RequestHandlerFactory& m_handlerFactory;

	RequestResult login(RequestInfo request);
	RequestResult signup(RequestInfo request);
public:
	LoginRequestHandler(RequestHandlerFactory& handlerFactory);
	bool isRequestRelevant(RequestInfo request);
	RequestResult handleRequest(RequestInfo request);
};

class RequestHandlerFactory;
class MenuRequestHandler : public IRequestHandler
{
public:
	bool isRequestRelevant(RequestInfo request);
	RequestResult handleRequest(RequestInfo request);
};
