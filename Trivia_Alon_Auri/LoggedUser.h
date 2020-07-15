#pragma once
#include <string>

class LoggedUser
{
private:
	std::string m_username;
public:

	LoggedUser(std::string username);
	//get the name of the user
	std::string getUserName() const;
	bool operator<(const LoggedUser& other) const;
};