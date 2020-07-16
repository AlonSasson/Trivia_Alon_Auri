#include "Room.h"
#include <iostream>

// adds a user to the room
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

// removes a user from the room
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

// gets all users in the room
std::vector<std::string> Room::getAllUsers()
{
	std::vector<std::string> users;
	for (auto it = m_users.begin(); it != m_users.end(); it++)
	{
		users.push_back(it->getUserName());
	}
	return users;
}

// gets the room's matadata
RoomData Room::getRoomData()
{
	return m_metadata;
}

unsigned int Room::isActive()
{
	return m_metadata.isActive;
}

void Room::setRoomState(unsigned int newState)
{
	this->m_metadata.isActive = newState;
}

Room::Room(RoomData roomData, LoggedUser user)
{
	this->m_metadata = roomData;
	this->addUser(user);
}
