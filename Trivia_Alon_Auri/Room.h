#pragma once
#include <string>
#include <vector>
#include "LoggedUser.h"

typedef struct RoomData
{
	unsigned int id;
	std::string name;
	unsigned int maxPlayers;
	unsigned int timePerQuestion;
	unsigned int isActive;
}RoomData;


class Room
{
private:

	RoomData m_metadata;

public:
	std::vector<LoggedUser> m_users;

	//manage users inside room 
	bool addUser(LoggedUser user);
	bool removeUser(LoggedUser user);
	std::vector<std::string> getAllUsers();
	RoomData getRoomData();
	unsigned int isActive();
	void setRoomState(unsigned int newState);

	Room(RoomData roomData, LoggedUser user); //C'tor

	enum RoomState
	{
		ROOM_WAITING_FOR_PLAYERS = 0,
		ROOM_WHILE_GAME,
		ROOM_GAME_ENDED,
		ROOM_FULL
	};
};
