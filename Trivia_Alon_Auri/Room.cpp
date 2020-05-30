#include "Room.h"

bool Room::addUser(LoggedUser user)
{
	for (auto it = m_users.begin(); it != m_users.end(); it++)
	{
		if (it->getUserName() == user.getUserName())
		{
			return false;
		}
	}
	m_users.push_back(user);
	return true;
}

bool Room::removeUser(LoggedUser user)
{
	for (auto it = m_users.begin(); it != m_users.end(); it++)
	{
		if (it->getUserName() == user.getUserName())
		{
			m_users.erase(it);
			return true;
		}
	}
	return false;
}

std::vector<std::string> Room::getAllUsers()
{
	std::vector<std::string> users;
	for (auto it = m_users.begin(); it != m_users.end(); it++)
	{
		users.push_back(it->getUserName());
	}
	return users;
}

RoomData Room::getRoomData()
{
	return m_metadata;
}

Room::Room(RoomData roomData , LoggedUser user)
{
	this->m_metadata = roomData;
	this->addUser(user);
}
