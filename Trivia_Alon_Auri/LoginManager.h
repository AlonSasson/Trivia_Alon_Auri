#pragma once
#include <string>

class LoginManager
{
public:
	unsigned int login(std::string username, std::string password);
	unsigned int signup(std::string username, std::string password, std::string email, std::string address, std::string phoneNumber, std::string birthDate);
	unsigned int logout(std::string username);
private:
	unsigned int validateInfo(std::string password, std::string email, std::string address, std::string phoneNumber, std::string birthDate);
};