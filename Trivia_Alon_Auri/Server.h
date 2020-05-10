#pragma once
#include "Communicator.h"

class Server
{
public:
	void run(const int port);  // runs server with a given port
private:
	Communicator m_communicator;
};
