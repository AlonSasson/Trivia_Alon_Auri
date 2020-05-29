#pragma once
#include "Requests.h"

#define SIGN_UP_ID 1
#define LOGIN_ID 2

class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(unsigned char* buffer); // deserializes json from requests into structs
	static SignupRequest deserializeSignupRequest(unsigned char* buffer);

	static JsonRequestPacketDeserializer& getInstance();

	JsonRequestPacketDeserializer(JsonRequestPacketDeserializer const&) = delete;
	void operator=(JsonRequestPacketDeserializer const&) = delete;
private:
	JsonRequestPacketDeserializer() {}
};