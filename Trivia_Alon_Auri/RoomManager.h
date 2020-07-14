#pragma once

#include "Room.h"
#include <map>

class RoomManager
{
private:
	std::map<unsigned int, Room> m_rooms;
	static unsigned int roomCount;
	RoomManager() {}

public:
	static RoomManager& getInstance();

	RoomManager(RoomManager const&) = delete;
	void operator=(RoomManager const&) = delete;

	bool createRoom(LoggedUser user, RoomData roomData);
	bool deleteRoom(int ID);
	unsigned int getRoomState(unsigned int roomId);
	std::vector<RoomData> getRooms();
	Room &getRoom(unsigned int roomId);
	unsigned int getNextRoomId();
	bool doesRoomExist(std::string room_name);

};