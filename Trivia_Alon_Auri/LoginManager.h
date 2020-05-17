#pragma once
#include <string>
#include <vector>
#include <mutex>
#include "LoggedUser.h"
#include "IdataBase.h"

class LoginManager
{
public:
	LoginManager(IDatabase* database);
	unsigned int login(std::string username, std::string password);
	unsigned int signup(std::string username, std::string password, std::string email, std::string address, std::string phoneNumber, std::string birthDate);
	unsigned int logout(std::string username);
private:
	unsigned int validateInfo(std::string password, std::string email, std::string address, std::string phoneNumber, std::string birthDate);
	std::vector<LoggedUser> m_loggedUsers;
	IDatabase* m_database;
	std::mutex m_dbLock;
};