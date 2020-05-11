#pragma once

#include "json.hpp"
#include "Respone.h"

#define LENGTH_OF_CONST_PACKET_DATA 5
class JsonResponsePacketSerializer
{
public:
	/*
		serialize login response 
	*/
	static char* serializeResponse(LoginResponse respone)
	{
		nlohmann::json j = respone;
		char* buffer = new char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = 1;
		std::memcpy((buffer + 1) , convertToGetLength(j.dump().length()) , 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
	/*
		serialize sign up response
	*/
	static char* serializeResponse(SignupResponse respone)
	{
		nlohmann::json j = respone;
		char* buffer = new char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = 2;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
	/*
		serialize error response 
	*/
	static char* serializeResponse(ErrorResponse respone)
	{
		nlohmann::json j = respone;
		char* buffer = new char[j.dump().length() + LENGTH_OF_CONST_PACKET_DATA];
		buffer[0] = 3;
		std::memcpy((buffer + 1), convertToGetLength(j.dump().length()), 4);
		std::memcpy((buffer + 5), j.dump().c_str(), j.dump().length());
		return buffer;
	}
private:
	/*
	the function get the length of the jason and convert it to char*
	*/
	static char* convertToGetLength(int len)
	{
		char* buffer = new char[4];
		int i = 0;
		const int byteSize = 256;
		int addToBuffer;
		for (i = 0; i < 4 ; i++)
		{
			addToBuffer = len % byteSize;
			len /= byteSize;
			buffer[3 - i] = addToBuffer;
		}
		return buffer;
	}
};