#pragma once
#include "IDatabase.h"
#include "LoginManager.h"
#include "RequestHandlers.h"

class LoginRequestHandler;
class MenuRequestHandler;
class RequestHandlerFactory
{
private:

	IDatabase* m_database;
	RequestHandlerFactory(IDatabase* database) : m_database(database) {}
public:

	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler();
	LoginManager& getLoginManager();

	static RequestHandlerFactory& getInstance(IDatabase* database);

	RequestHandlerFactory(RequestHandlerFactory const&) = delete;
	void operator=(RequestHandlerFactory const&) = delete;
};