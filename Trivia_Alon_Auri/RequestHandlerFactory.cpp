#include "RequestHandlerFactory.h"


// creates a login request handler
LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	RequestHandlerFactory* handlerFactory = this;
	return new LoginRequestHandler(*handlerFactory);
}

// creates a menu request handler
MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler(LoggedUser m_user)
{
	RequestHandlerFactory* handlerFactory = this;
	return new MenuRequestHandler(*handlerFactory, m_user);
}

// gets the login manager
LoginManager& RequestHandlerFactory::getLoginManager()
{
	return LoginManager::getInstance(this->m_database);
}

// gets the statistics manager
StatisticsManager& RequestHandlerFactory::getStatisticsManager()
{
	return StatisticsManager::getInstance(this->m_database);
}

// gets the room manager
RoomManager& RequestHandlerFactory::getRoomManager()
{
	return RoomManager::getInstance();
}

RequestHandlerFactory& RequestHandlerFactory::getInstance(IDatabase* database)
{
	static RequestHandlerFactory instance(database);
	return instance;
}
