#include "RoomManager.h"

unsigned int RoomManager::roomCount = 0;

// creates a room
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
	roomCount++;
	return true;
}

// deletes a room
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

// gets a room's state
unsigned int RoomManager::getRoomState(unsigned int roomId)
{
	return m_rooms.at(roomId).isActive();
}

// gets all rooms
std::vector<RoomData> RoomManager::getRooms()
{
	std::vector<RoomData> roomData;

	for (std::map<unsigned int, Room>::iterator it = this->m_rooms.begin(); it != this->m_rooms.end(); ++it)
	{
		roomData.push_back(it->second.getRoomData());
	}
	return roomData;
}

// gets a room
Room RoomManager::getRoom(unsigned int roomId)
{
	return m_rooms.at(roomId);
}

RoomManager& RoomManager::getInstance()
{
	static RoomManager instance;
	return instance; 
}

unsigned int RoomManager::getNextRoomId()
{
	return roomCount + 1;
}