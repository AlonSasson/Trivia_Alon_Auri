#include "Communicator.h"
#include <exception>
#include <iostream>
#include <thread>

using std::cout;
using std::cerr;
using std::endl;
using std::string;
using std::thread;
using std::exception;

#define DATA_SIZE 5

// C'TOR
Communicator::Communicator()
{
	this->m_serverSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (this->m_serverSocket == INVALID_SOCKET) // if the socket was invalid
		throw exception(__FUNCTION__ " - socket");
}

// D'TOR
Communicator::~Communicator()
{
	auto it = this->m_clients.begin();
	try
	{
		closesocket(this->m_serverSocket);
		for (it = this->m_clients.begin(); it != this->m_clients.end(); it++) // close all client sockets
		{
			closesocket(it->first);
		}
	}
	catch (...) {}
}

// bind and listen on server socket
void Communicator::bindAndListen(const int port)
{
	struct sockaddr_in sa = { 0 };

	sa.sin_family = AF_INET;
	sa.sin_addr.s_addr = INADDR_ANY;
	sa.sin_port = htons(port);

	// binding the socket
	cout << "Binding..." << endl;
	if (bind(this->m_serverSocket, (struct sockaddr*) & sa, sizeof(sa)) == SOCKET_ERROR)
		throw exception(__FUNCTION__ " - bind");

	// listening for clients
	cout << "Listening..." << endl;
	if (listen(this->m_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		throw exception(__FUNCTION__ " - listen");

}

// starts handling requests from clients
void Communicator::startHandleRequests(const int port)
{
	SOCKET client_socket;

	bindAndListen(port); 
	while (true) // accept new clients that join and send them to handler
	{
		client_socket = ::accept(this->m_serverSocket, NULL, NULL);
		this->m_clients[client_socket] = (IRequestHandler*)(new LoginRequestHandler()); // add client socket and request handler to client map
		thread(&Communicator::handleNewClient, this, client_socket).detach(); 
	}
}

// handles requests from a client
void Communicator::handleNewClient(SOCKET clientSocket)
{
	string data;
	char buffer[DATA_SIZE];

	if (clientSocket == INVALID_SOCKET)
	{
		cerr << "Failed to accept client";
		_exit(1);
	}
	cout << "Client accepted!" << endl;

	data = "Hello";
	if (send(clientSocket, data.c_str(), data.size(), NULL) == INVALID_SOCKET) // if sending the data failed
		cerr << "Failed to send data to client";

	if (recv(clientSocket, buffer, DATA_SIZE, NULL) == INVALID_SOCKET) // if recieving the data failed
		cerr << "Failed to read data from socket";
	data = buffer;

	cout << "Client" + std::to_string(clientSocket) + ": " + data << endl;

}

