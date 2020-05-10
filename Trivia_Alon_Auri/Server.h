#pragma once

#include <WinSock2.h>
#include <Windows.h>
#include <map>
#include <thread>
#include <vector>
#include <string>
#include <mutex>
#include <queue>

class Server
{
public:
	Server(); // C'TOR
	~Server(); // D'TOR
	void serve(int port);  // start function for serving clients

private:

	void accept(SOCKET clientSocket); // accepts a new client
	std::string login(SOCKET clientSocket); // logins a new client
	void update(SOCKET clientSocket, std::string name); // handles update messages 
	void clientHandler(SOCKET clientSocket); // handles messages from client
	void handleMessages(); // handles messages sent to other clients
	
	std::mutex _usersLock;
	std::mutex _msgLock;
	std::condition_variable	_cond;
	std::vector<std::thread> _threads;
	std::map<std::string, SOCKET> _clientsSockets;
	std::queue<std::string> _messages;
	SOCKET _serverSocket;

};
