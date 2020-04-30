#include "Server.h"
#include <thread>
#include <iostream>

#define EXIT_MSG "EXIT"

// runs server with a given port
void Server::run(const int port)
{
	std::thread t_connector(&Communicator::startHandleRequests, m_communicator, port); // start handling requests
	t_connector.detach();
	std::string input = "";

	while (input != EXIT_MSG) // keep going until exit msg is recieved
	{
		std::cin >> input;
	}
	
}
