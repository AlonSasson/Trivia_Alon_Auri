#include "LoggedUser.h"

LoggedUser::LoggedUser(std::string username)
	: m_username(username)
{
}
/*
return the user name
*/
std::string LoggedUser::getUserName() const
{
	return this->m_username;
}

bool LoggedUser::operator<(const LoggedUser& other) const
{
	return this->m_username < other.m_username;
}
