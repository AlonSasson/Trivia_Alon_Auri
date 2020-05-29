#include "RoomManager.h"

bool RoomManager::createRoom(LoggedUser user, RoomData roomData)
{
	for (std::map<unsigned int, Room>::iterator it = this->m_rooms.begin(); it != this->m_rooms.end(); ++it)
	{
		if (it->first == roomData.id)
		{
			return false;
		}
	}
	m_rooms.insert(std::pair<unsigned int , Room>(roomData.id, Room(roomData, user)));
	return true;
}

bool RoomManager::deleteRoom(int ID)
{
	for (std::map<unsigned int, Room>::iterator it = this->m_rooms.begin(); it != this->m_rooms.end(); ++it)
	{
		if (it->first == ID)
		{
			this->m_rooms.erase(it);
			return true;
		}
	}
	return false;
}

unsigned int RoomManager::getRoomState(int ID)
{
	return ROOM_NOT_EXIST;
}

std::vector<RoomData> RoomManager::getRooms()
{
	std::vector<RoomData> roomData;

	for (std::map<unsigned int, Room>::iterator it = this->m_rooms.begin(); it != this->m_rooms.end(); ++it)
	{
		roomData.push_back(it->second.getRoomData());
	}
	return roomData;
}
