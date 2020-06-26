#include "Requests.h"
#include <cstdint>
#include <iostream>
#include <vector>

using nlohmann::json;

void from_json(const json& j, LoginRequest& request) {
	j.at("Username").get_to(request.username);
	j.at("Password").get_to(request.password);
}

void from_json(const json& j, SignupRequest& request) {
	j.at("Username").get_to(request.username);
	j.at("Password").get_to(request.password);
	j.at("Email").get_to(request.email);
	j.at("Address").get_to(request.address);
	j.at("PhoneNumber").get_to(request.phoneNumber);
	j.at("BirthDate").get_to(request.birthDate);
}

void from_json(const nlohmann::json& j, CreateRoomRequest& request)
{
	j.at("RoomName").get_to(request.roomName);
	j.at("MaxUsers").get_to(request.maxUsers);
	j.at("QuestionCount").get_to(request.questionCount);
	j.at("AnswerTimeout").get_to(request.answerTimeout);
}

void from_json(const nlohmann::json& j, GetPlayersInRoomRequest& request)
{
	j.at("RoomId").get_to(request.roomId);
}

void from_json(const nlohmann::json& j, JoinRoomRequest& request)
{
	j.at("RoomId").get_to(request.roomId);
}