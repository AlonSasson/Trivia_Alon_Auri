#pragma once
#include "RequestHandlers.h"
#include <WinSock2.h>
#include <Windows.h>
#include <map>
#include <string>

class Communicator
{
public:
	Communicator(IDatabase* database); // C'TOR
	~Communicator(); // D'TOR

	void bindAndListen(const int port); // bind and listen on server socket
	void startHandleRequests(const int port); // starts handling requests from clients

private:
	void handleNewClient(SOCKET clientSocket); // handles requests from a client
	unsigned int decodeRequestLen(unsigned char* buffer); // converts the request length from bytes to int

	std::map<SOCKET, IRequestHandler*> m_clients;
	SOCKET m_serverSocket;
	IDatabase* m_database;
};