#pragma once
#include <string>
#include <vector>
#include "LoggedUser.h"
#include "IdataBase.h"
#include <mutex>

class LoginManager
{
public:
	unsigned int login(std::string username, std::string password);
	unsigned int signup(std::string username, std::string password, std::string email, std::string address, std::string phoneNumber, std::string birthDate);
	unsigned int logout(std::string username);

	static LoginManager& getInstance(IDatabase* database);

	LoginManager(LoginManager const&) = delete;
	void operator=(LoginManager const&) = delete;
private:
	unsigned int validateInfo(std::string password, std::string email, std::string address, std::string phoneNumber, std::string birthDate);
	std::vector<LoggedUser> m_loggedUsers;
	IDatabase* m_database;
	LoginManager(IDatabase* database) { this->m_database = database; }

	std::mutex m_dbLock;
};