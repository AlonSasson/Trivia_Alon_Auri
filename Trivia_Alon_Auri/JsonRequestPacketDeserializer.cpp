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

// deserializes json into GetPlayersInRoomRequest struct
GetPlayersInRoomRequest JsonRequestPacketDeserializer::deserializeGetPlayersInRoomRequest(unsigned char* buffer)
{
	std::string data = (char*)buffer;
	json j = json::parse(data);
	return  j.get<GetPlayersInRoomRequest>();
}

// deserializes json into JoinRoomRequest struct
JoinRoomRequest JsonRequestPacketDeserializer::deserializeJoinRoomRequest(unsigned char* buffer)
{
	std::string data = (char*)buffer;
	json j = json::parse(data);
	return  j.get<JoinRoomRequest>();
}

// deserializes json into CreateRoomRequest struct
CreateRoomRequest JsonRequestPacketDeserializer::deserializeCreateRoomRequest(unsigned char* buffer)
{
	std::string data = (char*)buffer;
	json j = json::parse(data);
	return  j.get<CreateRoomRequest>();
}

SubmitAnswerReqest JsonRequestPacketDeserializer::deserializerSubmitAnswerRequest(unsigned char* buffer)
{
	std::string data = (char*)buffer;
	json j = json::parse(data);
	return  j.get<SubmitAnswerReqest>();
}

JsonRequestPacketDeserializer& JsonRequestPacketDeserializer::getInstance()
{
	static JsonRequestPacketDeserializer instance;
	return instance;
}