#pragma once

#include "json.hpp"
#include "respone.h"


#define LENGTH_OF_CONST_PACKET_DATA 5
class JsonResponsePacketSerializer
{
private:
	
	enum returnCodeId
	{
		ERROR_MSG_ID,
		SIGN_UP_ID,
		LOGIN_ID,
		LOGOUT,
		GET_ROOMS,
		GET_PLAYERS_IN_ROOM,
		JOIN_ROOM,
		CREATE_ROOM,
		GET_STATICS,
		CLOSE_ROOM,
		START_GAME,
		GET_ROOM_STATE,
		LEAVE_ROOM
	};
public:
	/*
		serialize login response
	*/
	static unsigned char* serializeResponse(LoginResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
	/*
		serialize sign up response
	*/
	static unsigned char* serializeResponse(SignupResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = SIGN_UP_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
	/*
		serialize error response
	*/
	static unsigned char* serializeResponse(ErrorResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = ERROR_MSG_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeLogoutResponse(LogoutResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGOUT;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeGetRoomResponse(GetRoomsResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = GET_ROOMS;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeGetPlayersInRoomResponse(GetPlayersInRoomResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = GET_PLAYERS_IN_ROOM;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeJoinRoomResponse(JoinRoomResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = JOIN_ROOM;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeCreateRoomResponse(CreateRoomResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = CREATE_ROOM;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
		
	static unsigned char* serializeHighScoreResponse(getStaticsResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = GET_STATICS;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeCloseRoomResponse(CloseRoomResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = CLOSE_ROOM;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeCloseRoomResponse(StartGameResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = START_GAME;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeCloseRoomResponse(GetRoomStateResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = GET_ROOM_STATE;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeCloseRoomResponse(LeaveRoomResponse response)
	{
		nlohmann::json j = response;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LEAVE_ROOM;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}


	static JsonResponsePacketSerializer& getInstance()
	{
		static JsonResponsePacketSerializer instance;
		return instance;
	}
	JsonResponsePacketSerializer(JsonResponsePacketSerializer const&) = delete;
	void operator=(JsonResponsePacketSerializer const&) = delete;

private:
	/*
	the function get the length of the jason and convert it to char*
	*/
	static unsigned char* convertToGetLength(int len)
	{
		unsigned char* buffer = new unsigned char[4];
		int i = 0;
		const int byteSize = 256;
		int addToBuffer;
		for (i = 0; i < 4; i++)
		{
			addToBuffer = len % byteSize;
			len /= byteSize;
			buffer[3 - i] = addToBuffer;
		}
		return buffer;
	}
	JsonResponsePacketSerializer() {}
};