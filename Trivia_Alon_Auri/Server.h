#pragma once
#include "Communicator.h"
#include "IDatabase.h"

class Server
{
public:
	Server(); 
	~Server();
	void run(const int port);  // runs server with a given port
private:
	Communicator m_communicator;
	IDatabase* m_database;
};
