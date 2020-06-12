#pragma once
#include <string>
#include <vector>
#include "LoggedUser.h"

typedef struct RoomData
{
	unsigned int id;
	std::string name;
	int maxPlayers;
	unsigned int timePerQuestion;
	unsigned isActive;
}RoomData;

class Room
{
private:

	RoomData m_metadata;
	std::vector<LoggedUser> m_users;

public:

	//manage users inside room 
	bool addUser(LoggedUser user);
	bool removeUser(LoggedUser user);
	std::vector<std::string> getAllUsers();
	RoomData getRoomData();

	Room(RoomData roomData , LoggedUser user); //C'tor
};

