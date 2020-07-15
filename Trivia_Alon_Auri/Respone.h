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

struct CloseRoomResponse
{
	unsigned int status;
}typedef CloseRoomResponse;

struct StartGameResponse
{
	unsigned int status;
}typedef StartGameResponse;

struct GetRoomStateResponse
{
	unsigned int status;
	unsigned int hasGameBegun;
	std::vector<std::string> players;
	unsigned int questionCount;
	unsigned int answerTimeout;
}typedef GetRoomStateResponse;

struct LeaveRoomResponse
{
	unsigned int status;
}typedef LeaveRoomResponse;

struct LeaveGameResponse
{
	unsigned int status;
}typedef LeaveGameResponse;

struct GetQuestionsResponse
{
	unsigned int status;
	std::string question;
	std::map<unsigned int, std::string> answers;
}typedef GetQestionResponse;

struct SubmitAnswerResponse
{
	unsigned int status;
	unsigned int correctAnswerId;
}typedef SubmitAnswerResponse;

typedef struct PlayerResults
{
	std::string username;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;

} PlayerResults;


struct GetGameResultResponse
{
	unsigned int status;
	std::vector<PlayerResults> results;

}typedef GetGameResultResponse;



void to_json(json& j, const LoginResponse& respone) {
	j = json{ {"Status", respone.status} };
}
void to_json(json& j, const SignupResponse& respone) {
	j = json{ {"Status", respone.status} };
}
void to_json(json& j, const ErrorResponse& respone) {
	j = json{ {"Message", respone.message} };
}
void to_json(json& j, const LogoutResponse& respone)
{
	j = json{ {"Status", respone.status} };
}
void to_json(json& j, const JoinRoomResponse& respone)
{
	j = json{ {"Status", respone.status} };
}
void to_json(json& j, const GetRoomsResponse& respone)
{
	json structHold;
	std::vector<json> addToJson;
	for (auto it = respone.rooms.begin();it != respone.rooms.end();it++)
	{
		structHold["Id"] = it->id;
		structHold["HasGameBegun"] = it->isActive;
		structHold["MaxPlayers"] = it->maxPlayers;
		structHold["Name"] = it->name;
		structHold["TimePerQuestion"] = it->timePerQuestion;

		addToJson.push_back(structHold);
	}

	j = json{ {"Status", respone.status } , {"Rooms" , addToJson } };
}


void to_json(json& j, const CreateRoomResponse& respone)
{
	j = json{ {"Status", respone.status} };
}
void to_json(json& j, const GetPlayersInRoomResponse& respone)
{
	j = json{ {"Players", respone.players} };
}

void to_json(json& j, const getStaticsResponse& respone)
{
	j = json{ {"Status", respone.status }, { "HighScores" , respone.highScores }, { "Statistics" , respone.statics } };
}

void to_json(json& j, const CloseRoomResponse& response)
{
	j = json{ {"Status" , response.status } };
}

void to_json(json& j, const StartGameResponse& response)
{
	j = json{ {"Status" , response.status } };
}

void to_json(json& j, const GetRoomStateResponse& response)
{
	j = json{ {"Status" , response.status } ,{ "HasGameBegun" , response.hasGameBegun },{ "Players" , response.players },{ "QuestionCount" , response.questionCount },{ "AnswerTimeout" , response.answerTimeout} };

}

void to_json(json& j, const LeaveRoomResponse& response)
{
	j = json{ {"Status" , response.status } };
}

void to_json(json& j, const LeaveGameResponse& response)
{
	j = json{ {"Status" , response.status } };
}

void to_json(json& j, const GetQestionResponse& response)
{
	j = json{ {"Status" , response.status , "Question" , response.question , "Answers" , response.answers} };
}
void to_json(json& j, const SubmitAnswerResponse& response)
{
	j = json{ {"Status" , response.status , "CorrectAnswerId" , response.correctAnswerId} };
}
void to_json(json& j, const GetGameResultResponse& response)
{
	json structHold;

}
