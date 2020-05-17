#pragma once
#include "IDatabase.h"
#include "LoginManager.h"
#include "RequestHandlers.h"

class LoginRequestHandler;
class MenuRequestHandler;
class RequestHandlerFactory
{
private:
	LoginManager m_loginManager;
	IDatabase*  m_database;
public:
	RequestHandlerFactory(IDatabase* database);
	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler();
	LoginManager& getLoginManager();
};