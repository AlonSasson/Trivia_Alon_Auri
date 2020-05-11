#pragma once
#include "Requests.h"

class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(char* buffer); // deserializes json from requests into structs
	static SignupRequest deserializeSignupRequest(char* buffer);
};