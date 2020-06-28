#pragma once
#include "Requests.h"


class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(unsigned char* buffer); // deserializes json from requests into structs
	static SignupRequest deserializeSignupRequest(unsigned char* buffer);
	static GetPlayersInRoomRequest deserializeGetPlayersInRoomRequest(unsigned char* buffer);
	static JoinRoomRequest deserializeJoinRoomRequest(unsigned char* buffer);
	static CreateRoomRequest deserializeCreateRoomRequest(unsigned char* buffer);

	static JsonRequestPacketDeserializer& getInstance();

	JsonRequestPacketDeserializer(JsonRequestPacketDeserializer const&) = delete;
	void operator=(JsonRequestPacketDeserializer const&) = delete;
private:
	JsonRequestPacketDeserializer() {}
};