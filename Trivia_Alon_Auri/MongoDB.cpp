#include "MongoDB.h"
#include <iostream>
#include "json.hpp"

/*
check if user name exist in db
*/
bool mongoDB::doesUserExist(std::string username)
{
	bsoncxx::builder::stream::document document{};
	document << "username" << username;
	auto search_result = this->db["User"].find_one(document.view());
	return (bool)search_result;
}
/*
check if user name much password
*/
bool mongoDB::doesPasswordMatch(std::string username, std::string password)
{
	bsoncxx::builder::stream::document document{};
	document << "username" << username << "password" << password;
	auto search_result = this->db["User"].find_one(document.view());
	return (bool)search_result;
}

/*
add new user to the data base
*/
bool mongoDB::addNewUser(std::string username, std::string password, std::string mail, std::string address, std::string phone_number, std::string birthday)
{

	if (!this->doesUserExist(username))
	{
		bsoncxx::builder::stream::document document{};
		document << "username" << username << "password" << password << "mail" << mail << "address" << address << "phone_number" << phone_number << "birthday" << birthday;
		auto collection = this->db["User"];
		collection.insert_one(document.view());
		return true;
	}
	return false;

}
/*
open a data base
*/
void mongoDB::open()
{
	mongocxx::instance inst{};
	mongocxx::client* client = new mongocxx::client{ mongocxx::uri{} };
	this->client = client;
	this->db = (*client)["TriviaProjectDB"];
	this->db["User"];
}

// deletes the client
void mongoDB::close()
{
	delete this->client;
}
