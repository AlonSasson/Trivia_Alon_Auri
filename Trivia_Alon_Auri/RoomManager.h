#pragma once

#include "Room.h"
#include <map>

class RoomManager
{
private:
	std::map<unsigned int, Room> m_rooms;

	enum RoomState
	{
		ROOM_NOT_EXIST = 0,
		ROOM_WHILE_GAME,
		ROOM_GAME_ENDED
	};

public:
	bool createRoom(LoggedUser user, RoomData roomData);
	bool deleteRoom(int ID);
	unsigned int getRoomState(int ID);
	std::vector<RoomData> getRooms();
};