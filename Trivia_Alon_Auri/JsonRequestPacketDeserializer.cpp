#include "JsonRequestPacketDeserializer.h"
#include <string>

using nlohmann::json;

// deserializes json into LoginRequest struct
LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(char* buffer)
{
	std::string data = buffer;
	json j = json::parse(data);
	return  j.get<LoginRequest>();
}

// deserializes json into SignupRequest struct
SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(char* buffer)
{
	std::string data = buffer;
	json j = json::parse(data);
	return  j.get<SignupRequest>();
}
