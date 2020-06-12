#pragma once

#include "json.hpp"
#include "Respone.h"

#define ERROR_MSG_ID 0
#define SIGN_UP_ID 1
#define LOGIN_ID 2

#define LENGTH_OF_CONST_PACKET_DATA 5
class JsonResponsePacketSerializer
{
public:
	/*
		serialize login response
	*/
	static unsigned char* serializeResponse(LoginResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
	/*
		serialize sign up response
	*/
	static unsigned char* serializeResponse(SignupResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = SIGN_UP_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
	/*
		serialize error response
	*/
	static unsigned char* serializeResponse(ErrorResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeLogoutResponse(LogoutResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeGetRoomResponse(GetRoomsResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeGetPlayersInRoomResponse(GetPlayersInRoomResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeJoinRoomResponse(JoinRoomResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}

	static unsigned char* serializeCreateRoomResponse(CreateRoomResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
		
	static unsigned char* serializeHighScoreResponse(getStaticsResponse respone)
	{
		nlohmann::json j = respone;
		unsigned char* buffer = new unsigned char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = LOGIN_ID;
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