#pragma once
#include "Requests.h"
#include <ctime>
#include <iostream>

class IRequestHandler;
typedef struct RequestResult
{
	char* response;
	IRequestHandler* newHandler;
}RequestResult;

class IRequestHandler
{
public:
	virtual bool isRequestRelevant(RequestInfo request) = 0;
	virtual RequestResult handleRequest(RequestInfo request) = 0;
};

class LoginRequestHandler : public IRequestHandler
{
public:
	bool isRequestRelevant(RequestInfo request);
	RequestResult handleRequest(RequestInfo request);
};

