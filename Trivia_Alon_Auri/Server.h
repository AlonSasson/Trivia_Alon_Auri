#pragma once
#include "Communicator.h"
#include "IDatabase.h"

class Server
{
public:
	~Server();

	void run(const int port);  // runs server with a given port

	static Server& getInstance();

	Server(Server const&) = delete;
	void operator=(Server const&) = delete;

private:
	IDatabase* m_database;
	Communicator m_communicator;
	Server();
};
