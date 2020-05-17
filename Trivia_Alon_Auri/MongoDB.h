#pragma once
#include <string>
#include <bsoncxx/builder/stream/document.hpp>
#include <cstdint>
#include <bsoncxx/json.hpp>
#include <mongocxx/client.hpp>
#include <mongocxx/stdx.hpp>
#include <mongocxx/uri.hpp>
#include <mongocxx/instance.hpp>
#include "IDatabase.h"

class mongoDB : public IDatabase
{
private:
	mongocxx::database db;
	mongocxx::client* client;
public:

	bool doesUserExist(std::string username);
	bool doesPasswordMatch(std::string username, std::string password);

	bool addNewUser(std::string username, std::string password, std::string mail, std::string address, std::string phone_number, std::string birthday);

	void open();
	void close();
};