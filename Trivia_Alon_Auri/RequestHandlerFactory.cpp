#include "RequestHandlerFactory.h"

RequestHandlerFactory::RequestHandlerFactory(IDatabase* database):
	m_database(database), m_loginManager(database)
{
}

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
	return m_loginManager;
}
