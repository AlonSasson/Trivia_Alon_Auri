#include "Server.h"
#include "Helper.h"
#include <exception>
#include <iostream>
#include <fstream>
#include <sstream>

using std::cout;
using std::cerr;
using std::endl;
using std::string;
using std::thread;
using std::exception;

#define CODE_LEN 3
#define LEN_USERNAME 2
#define LEN_CHAT_CONTENT 5
#define LEN_PAR_USERNAME 2
#define LEN_ALL_USERNAMES 5

#define INFO_DELIM "&"

// C'TOR
Server::Server()
{
	cout << "Starting..." << endl;
	this->_serverSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	
	if (this->_serverSocket == INVALID_SOCKET) // if the socket was invalid
		throw exception(__FUNCTION__ " - socket");
}

// D'TOR
Server::~Server()
{
	auto it = this->_clientsSockets.begin();
	try
	{
		closesocket(_serverSocket);
		for (it = this->_clientsSockets.begin(); it != this->_clientsSockets.end(); it++) // close all client sockets
		{
			this->_usersLock.lock(); // lock while accesing users / sockets
			closesocket(it->second);
			this->_usersLock.unlock();
		}		
	}
	catch (...) {}
}

// main function to serve all clients
void Server::serve(int port)
{

	struct sockaddr_in sa = { 0 };
	SOCKET client_socket;
	thread msgThread(&Server::handleMessages, this); // create thread for handling messages

	msgThread.detach();

	sa.sin_port = htons(port); // port that server will listen for
	sa.sin_family = AF_INET;   // must be AF_INET
	sa.sin_addr.s_addr = INADDR_ANY;   

	// binding the socket
	cout << "Binding..." << endl;
	if (bind(_serverSocket, (struct sockaddr*) & sa, sizeof(sa)) == SOCKET_ERROR)
		throw exception(__FUNCTION__ " - bind");
	

	// listening for clients
	cout << "Listening..." << endl;
	if (listen(_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		throw exception(__FUNCTION__ " - listen");

	while (true)
	{
		cout << "Accepting client..." << endl;
		client_socket = ::accept(_serverSocket, NULL, NULL); // wait for a new client
		this->_threads.push_back(thread(&Server::accept, this, client_socket)); // create a thread for new client
		this->_threads.back().detach();
	}
}

// accepts a new client
void Server::accept(SOCKET clientSocket)
{
	if (clientSocket == INVALID_SOCKET)
		throw exception(__FUNCTION__);

	cout << "Client accepted!" << endl;

	// the function that handle the conversation with the client
	clientHandler(clientSocket);
}

// logins a new client
string Server::login(SOCKET clientSocket) // logs in a new client
{
	unsigned int nameLen = Helper::getIntPartFromSocket(clientSocket, LEN_USERNAME);
	string name = Helper::getStringPartFromSocket(clientSocket, nameLen);
	string msg = "";
	std::vector<string> allUsernames;

	if (_clientsSockets.find(name) != _clientsSockets.end()) // if the username is already connected
	{
		throw exception("Error, username already connected.");
	}
	this->_usersLock.lock(); // lock while accesing users or sockets
	this->_clientsSockets[name] = clientSocket; // add client and socket to clients list
	allUsernames = Helper::getNamesFromMap(this->_clientsSockets); // get a vector of all connected users
	this->_usersLock.unlock();
	cout << "ADDED new client " + std::to_string(clientSocket) << ", " << name << " to clients list" << endl;
	Helper::send_update_message_to_client(clientSocket, "", "", Helper::getSortedNames(allUsernames));
	return name;
}

// handles update messages 
void Server::update(SOCKET clientSocket, string name)
{
	unsigned int nameLen = Helper::getIntPartFromSocket(clientSocket, LEN_USERNAME);
	unsigned int newMsgLen = 0;
	string secondName = Helper::getStringPartFromSocket(clientSocket, nameLen);
	string fileName = Helper::getSortedNames(std::vector<string>{name, secondName}) + ".txt";
	string allUsernames = Helper::getSortedNames(Helper::getNamesFromMap(this->_clientsSockets)); // get a sorted string of all connected users
	string newMsg = "";
	string chatContent = "";
	std::ifstream chatFile(fileName);
	std::ostringstream ostr;

	newMsgLen = Helper::getIntPartFromSocket(clientSocket, LEN_CHAT_CONTENT);
	newMsg = Helper::getStringPartFromSocket(clientSocket, newMsgLen);

	if (newMsg != "") // if there is a new msg
	{
		this->_msgLock.lock(); // lock while using msg queue
		this->_messages.push(name + INFO_DELIM + fileName + newMsg); // insert msg + names
		this->_msgLock.unlock();
		this->_cond.notify_one(); // notify messageHandler
	}

	if (chatFile.is_open()) // if file was opened
	{
		ostr << chatFile.rdbuf(); // read file into string
		chatContent = ostr.str();
		chatFile.close();
	}

	Helper::send_update_message_to_client(clientSocket, chatContent, secondName, allUsernames);
}

// handles messages from a client
void Server::clientHandler(SOCKET clientSocket)
{
	unsigned int code = 0;
	string name = "";

	try
	{
		while (true)
		{
			code = Helper::getIntPartFromSocket(clientSocket, CODE_LEN);
			switch (code)
			{
			case MT_CLIENT_LOG_IN:
				name = login(clientSocket);
				break;
			case MT_CLIENT_UPDATE:
				update(clientSocket, name);
				break;
			default:
				cerr << "Code: " << code << endl;
				throw exception("Error. Unrecognized message code.");
			}
		}
	}
	catch (const exception& e)
	{
		cerr << "Exception was caught in function " __FUNCTION__ ". socket = " << std::to_string(clientSocket) << ", " << e.what() << endl;
		if (name != "") // if the user managed to log in
		{
			cerr << "Recieved exit message from client" << endl;
			this->_usersLock.lock(); // lock while accesing users or sockets
			this->_clientsSockets.erase(name); // remove the client from the clients list
			this->_usersLock.unlock();
			cerr << "REMOVED " + std::to_string(clientSocket) << ", " << name << " from clients list" << endl;
		}
		closesocket(clientSocket);
	}


}

// handles messages sent to other clients
void Server::handleMessages()	
{
	std::unique_lock<std::mutex> msgLocker(this->_msgLock, std::defer_lock);
	std::ofstream chatFile;
	std::string fileName;
	std::string author;
	std::string msg;

	while (true)
	{
		msgLocker.lock();
		this->_cond.wait(msgLocker); // wait to be notified
		msg = this->_messages.front(); // get msg
		this->_messages.pop();
		msgLocker.unlock();

		author = msg.substr(0, msg.find(INFO_DELIM)); // get author name
		msg = msg.substr(msg.find(INFO_DELIM) + 1); 
		fileName = msg.substr(0, msg.find(".txt") + strlen(".txt")); // get file name from msg
		msg = msg.substr(msg.find(".txt") + strlen(".txt")); // get real msg

		chatFile.open(fileName, std::ios::app); // append to file
		if (chatFile.is_open()) // if file opened successfully
		{
			chatFile << "&MAGSH_MESSAGE&&Author&" + author + "&DATA&" + msg;
			chatFile.close();
		}
	}
}
