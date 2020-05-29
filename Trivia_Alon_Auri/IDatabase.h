#pragma once
#include <string>
class IDatabase
{
public:

	// queries
	virtual bool doesUserExist(std::string username) = 0;
	virtual bool doesPasswordMatch(std::string username , std::string password) = 0;

	// user related
	virtual bool addNewUser(std::string username, std::string password, std::string mail, std::string address, std::string phone_number, std::string birthday) = 0;

	//data base related
	virtual void open() = 0;
	virtual void close() = 0;

};