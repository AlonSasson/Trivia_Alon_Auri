#pragma once
#include "Requests.h"
#include <ctime>
#include <iostream>

class IRequestHandler;
typedef struct RequestResult
{
	char* respone;
	IRequestHandler* newHandler;
}RequestResult;

class IRequestHandler
{
public:
	virtual bool isRequestRelevant(RequestInfo respone) = 0;
	virtual RequestResult handleRequest(RequestInfo respone) = 0;
};

class LoginRequestHandler : public IRequestHandler
{
public:
	bool isRequestRelevant(RequestInfo respone);
	RequestResult handleRequest(RequestInfo respone);
};

