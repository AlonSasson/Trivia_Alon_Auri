#include "JsonRequestPacketDeserializer.h"
#include <string>

using nlohmann::json;

// deserializes json into LoginRequest struct
LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(unsigned char* buffer)
{
	std::string data = (char*)buffer;
	json j = json::parse(data);
	return  j.get<LoginRequest>();
}

// deserializes json into SignupRequest struct
SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(unsigned char* buffer)
{
	std::string data = (char*)buffer;
	json j = json::parse(data);
	return  j.get<SignupRequest>();
}
