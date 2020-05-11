#pragma once
#include "json.hpp"
#include <ctime>
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

} SignupRequest;

typedef struct RequestInfo
{
	int id;
	time_t receivalTime;
	char* buffer;
} RequestInfo;

// convert json data to a request struct

void from_json(const nlohmann::json& j, LoginRequest& request);
void from_json(const nlohmann::json& j, SignupRequest& request);