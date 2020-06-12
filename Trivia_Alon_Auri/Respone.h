#pragma once
#include <string>
#include "json.hpp"
#include "Room.h"
using nlohmann::json;

/*
	File with respone structs 
*/

struct LoginResponse
{
	unsigned int status;
} typedef LoginResponse;

struct SignupResponse
{
	unsigned int status;
} typedef SignupResponse;

struct ErrorResponse
{
	std::string message;
} typedef ErrorResponse;

struct LogoutResponse
{
	unsigned int status;
}typedef LogoutResponse;

struct JoinRoomResponse
{
	unsigned int status;
}typedef JoinRoomResponse;

struct GetRoomsResponse
{
	unsigned int status;
	std::vector<RoomData> rooms;
}typedef GetRoomsResponse;

struct CreateRoomResponse
{
	unsigned int status;
}typedef CreateRoomResponse;

struct GetPlayersInRoomResponse
{
	std::vector<std::string> players;
}typedef GetPlayersInRoomResponse;

struct getStaticsResponse
{
	unsigned int status;
	std::vector<std::string> highScores;
	std::string statics;
}typedef getStaticsResponse;

void to_json(json& j, const LoginResponse& respone) {
	j = json{ {"status", respone.status} };
}
void to_json(json& j, const SignupResponse& respone) {
	j = json{ {"status", respone.status} };
}
void to_json(json& j, const ErrorResponse& respone) {
	j = json{ {"message", respone.message} };
}
void to_json(json& j, const LogoutResponse& respone)
{
	j = json{ {"status", respone.status} };
}
void to_json(json& j, const JoinRoomResponse& respone)
{
	j = json{ {"status", respone.status} };
}
void to_json(json& j, const GetRoomsResponse& respone)
{
	json structHold;
	std::vector<std::string> addToJson;
	for (auto it = respone.rooms.begin();it != respone.rooms.end();it++)
	{
		structHold["id"] = it->id;
		structHold["isActive"] = it->isActive;
		structHold["maxPlayers"] =it->maxPlayers;
		structHold["name"] = it->name;
		structHold["timePerQuestion"] = it->timePerQuestion;

		addToJson.push_back(structHold);
	}

	j = json{ {"status", respone.status, "rooms" , addToJson} };

}
void to_json(json& j, const CreateRoomResponse& respone)
{
	j = json{ {"status", respone.status} };
}
void to_json(json& j, const GetPlayersInRoomResponse& respone)
{
	j = json{ {"players", respone.players} };
}

void to_json(json& j, const getStaticsResponse& respone)
{
	j = json{ {"status", respone.status, "highScores" , respone.highScores , "statistics" , respone.statics} };
}
