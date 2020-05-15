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


// convert json data to a request struct

void from_json(const nlohmann::json& j, LoginRequest& request);
void from_json(const nlohmann::json& j, SignupRequest& request);