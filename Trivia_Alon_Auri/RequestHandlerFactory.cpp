#include "RequestHandlerFactory.h"


// creates a login request handler
LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	RequestHandlerFactory* handlerFactory = this;
	return new LoginRequestHandler(*handlerFactory);
}

MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler()
{
	return new MenuRequestHandler;
}

// gets the login manager
LoginManager& RequestHandlerFactory::getLoginManager()
{
	return LoginManager::getInstance(this->m_database);
}

RequestHandlerFactory& RequestHandlerFactory::getInstance(IDatabase* database)
{
	static RequestHandlerFactory instance(database);
	return instance;
}
