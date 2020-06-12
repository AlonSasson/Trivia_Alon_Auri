#pragma once
#include "json.hpp"

#include <string>
typedef struct LoginRequest
{
	std::string username;
	std::string password;

} LoginRequest;

typedef struct SignupRequest
{
	std::string username;
	std::string password;
	std::string email;
	std::string address;
	std::string phoneNumber;
	std::string birthDate;

} SignupRequest;

typedef struct RequestInfo
{
	int id;
	time_t receivalTime;
	unsigned char* buffer;
} RequestInfo;

typedef struct CreateRoomRequest
{
	std::string roomName;
	unsigned int maxUsers;
	unsigned int questionCount;
	unsigned int answerTimeout;
}CreateRoomRequest;

typedef struct GetPlayersInRoomRequest
{
	unsigned int roomId;
}GetPlayersInRoomRequest;

typedef struct JoinRoomRequest
{
	unsigned int roomId;
}JoinRoomRequest;

typedef struct HighscoreRequest
{
	std::string username;
} HighscoreRequest;


// convert json data to a request struct

void from_json(const nlohmann::json& j, LoginRequest& request);
void from_json(const nlohmann::json& j, SignupRequest& request);
void from_json(const nlohmann::json& j, CreateRoomRequest& request);
void from_json(const nlohmann::json& j, GetPlayersInRoomRequest& request);
void from_json(const nlohmann::json& j, JoinRoomRequest& request);
void from_json(const nlohmann::json& j, HighscoreRequest& request);
