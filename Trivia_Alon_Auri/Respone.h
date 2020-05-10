#pragma once
#include <string>
#include "json.hpp"
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

void to_json(json& j, const LoginResponse& respone) {
	j = json{ {"status", respone.status} };
}
void to_json(json& j, const SignupResponse& respone) {
	j = json{ {"status", respone.status} };
}
void to_json(json& j, const ErrorResponse& respone) {
	j = json{ {"message", respone.message} };
}
