#include "Requests.h"

using nlohmann::json;

void from_json(const json& j, LoginRequest& request) {
	j.at("username").get_to(request.username);
	j.at("password").get_to(request.password);
}

void from_json(const json& j, SignupRequest& request) {
	j.at("username").get_to(request.username);
	j.at("password").get_to(request.password);
	j.at("email").get_to(request.email);
}