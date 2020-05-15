#include "Communicator.h"
#include "JsonRequestPacketDeserializer.h"
#include <exception>
#include <iostream>
#include <thread>
#include <cmath>

using std::cout;
using std::cerr;
using std::endl;
using std::string;
using std::thread;
using std::exception;

#define CODE_SIZE 1
#define LEN_SIZE 4

#define BYTE_SIZE 256


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
			delete it->second;
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
	SOCKET clientSocket;

	bindAndListen(port); 
	while (true) // accept new clients that join and send them to handler
	{
		clientSocket = ::accept(this->m_serverSocket, NULL, NULL);
		if (clientSocket == INVALID_SOCKET) // if client couldn't be accepted
			cerr << __FUNCTION__ " - Failed to accept client" << endl;
		cout << "Client accepted!" << endl;
		this->m_clients[clientSocket] = new LoginRequestHandler(); // add client socket and request handler to client map
		thread(&Communicator::handleNewClient, this, clientSocket).detach();
	}
}

// handles requests from a client
void Communicator::handleNewClient(SOCKET clientSocket)
{
	unsigned int len = 0;
	time_t receivalTime;
	unsigned char * buffer;
	RequestInfo requestInfo;
	RequestResult requestResult;
	
	while (true)
	{
		buffer = new unsigned char[CODE_SIZE];
		if (recv(clientSocket, (char* )buffer, CODE_SIZE, NULL) == INVALID_SOCKET) // if recieving the code failed
		{
			cerr << "Failed to read code from socket\n";
			delete[] buffer;
			break;
		}	
		requestInfo.receivalTime = time(&receivalTime);
		requestInfo.id = buffer[0];

		buffer = new unsigned char[LEN_SIZE];
		if (recv(clientSocket, (char*)buffer, LEN_SIZE, NULL) == INVALID_SOCKET) // if recieving the length failed
		{
			cerr << "Failed to read code from socket\n";
			delete[] buffer;
			break;
		}
		len = decodeRequestLen(buffer);
		delete[] buffer;

		buffer = new unsigned char[len];
		requestInfo.buffer = new unsigned char[len+1];
		if (recv(clientSocket, (char*)buffer, len, NULL) == INVALID_SOCKET) // if recieving the json data failed
		{
			cerr << "Failed to read code from socket\n";
			delete[] buffer;
			break;
		}
		std::memcpy(requestInfo.buffer, buffer, len); // deep copy json data
		requestInfo.buffer[len] = NULL;
		delete[] buffer;

		requestResult = m_clients[clientSocket]->handleRequest(requestInfo); // send the request to the client's current handler
		delete m_clients[clientSocket];
		m_clients[clientSocket] = requestResult.newHandler; // set the client's new handler
		delete[] requestInfo.buffer;

		len = CODE_SIZE + LEN_SIZE + decodeRequestLen(&requestResult.response[CODE_SIZE]) ; // get response length
		if (send(clientSocket, (char*)requestResult.response, len, NULL) == INVALID_SOCKET) // if sending the data failed
			cerr << "Failed to send data to client";
		delete[] requestResult.response;
	}
	closesocket(clientSocket);
	cerr << "Client " << clientSocket << " Disconnected" << endl;

}

// converts the request length from bytes to int
unsigned int Communicator::decodeRequestLen(unsigned char* buffer)
{
	int i = 0;
	unsigned int len = 0;

	for (i = 0; i < LEN_SIZE; i++) // go through each byte
	{
		len += buffer[i] * pow(BYTE_SIZE, LEN_SIZE - i - 1); // use formula to convert from byte to int
	}
	return len;
}

