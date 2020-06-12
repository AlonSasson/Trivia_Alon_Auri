#include "Requests.h"
#include <cstdint>
#include <iostream>
#include <vector>

using nlohmann::json;

void from_json(const json& j, LoginRequest& request) {
	j.at("username").get_to(request.username);
	j.at("password").get_to(request.password);
}

void from_json(const json& j, SignupRequest& request) {
	j.at("username").get_to(request.username);
	j.at("password").get_to(request.password);
	j.at("mail").get_to(request.email);
	j.at("address").get_to(request.address);
	j.at("phone_number").get_to(request.phoneNumber);
	j.at("birthday").get_to(request.birthDate);
}

void from_json(const nlohmann::json& j, CreateRoomRequest& request)
{
	j.at("roomName").get_to(request.roomName);
	j.at("maxUsers").get_to(request.maxUsers);
	j.at("questionCount").get_to(request.questionCount);
	j.at("answerTimeout").get_to(request.answerTimeout);
}

void from_json(const nlohmann::json& j, GetPlayersInRoomRequest& request)
{
	j.at("roomId").get_to(request.roomId);
}

void from_json(const nlohmann::json& j, JoinRoomRequest& request)
{
	j.at("roomId").get_to(request.roomId);
}

void from_json(const json& j, HighscoreRequest& request) {
	j.at("username").get_to(request.username);
}