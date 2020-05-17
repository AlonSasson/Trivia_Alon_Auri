#include "LoggedUser.h"

LoggedUser::LoggedUser(std::string username)
	: m_username(username)
{
}
/*
return the user name
*/
std::string LoggedUser::getUserName()
{
	return this->m_username;
}
