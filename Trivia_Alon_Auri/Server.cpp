#include "MongoDB.h"
#include "Server.h"
#include <thread>
#include <iostream>

#define EXIT_MSG "EXIT"

Server::Server():
	m_database(new mongoDB), m_handlerFactory(m_database), m_communicator(m_handlerFactory)
{
}

Server::~Server()
{
	delete this->m_database;
}

// runs server with a given port
void Server::run(const int port)
{
	m_database->open();
	std::thread t_connector(&Communicator::startHandleRequests, m_communicator, port); // start handling requests
	t_connector.detach();
	std::string input = "";

	while (input != EXIT_MSG) // keep going until exit msg is recieved
	{
		std::cin >> input;
	}
	this->m_database->close();
}
