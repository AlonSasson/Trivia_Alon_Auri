#include "MongoDB.h"
#include <iostream>
#include "json.hpp"
#include <ctime>
#include <cmath>

using bsoncxx::builder::basic::kvp;
using bsoncxx::builder::basic::make_document;

/*
check if user name exist in db
*/
bool mongoDB::doesUserExist(std::string username)
{
	bsoncxx::builder::stream::document document{};
	document << "username" << username;
	auto search_result = this->db["Users"].find_one(document.view());
	return (bool)search_result;
}
/*
check if user name much password
*/
bool mongoDB::doesPasswordMatch(std::string username, std::string password)
{
	bsoncxx::builder::stream::document document{};
	document << "username" << username << "password" << password;
	auto search_result = this->db["Users"].find_one(document.view());
	return (bool)search_result;
}

/*
add new user to the data base
*/
bool mongoDB::addNewUser(std::string username, std::string password, std::string mail, std::string address, std::string phone_number, std::string birthday)
{

	if (!this->doesUserExist(username))
	{
		bsoncxx::builder::stream::document userDoc{};
		bsoncxx::builder::stream::document staticsDoc{};
		userDoc << "username" << username << "password" << password << "mail" << mail << "address" << address << "phone_number" << phone_number << "birthday" << birthday;
		staticsDoc << "username" << username << "avg_answer_time" << 0 << "correct_answers" << 0 << "total_answers" << 0 << "games_played" << 0 << "score" << 0;
		auto collectionStatics = this->db["Statistics"];
		collectionStatics.insert_one(staticsDoc.view());
		auto collection = this->db["Users"];
		collection.insert_one(userDoc.view());
		return true;
	}
	return false;

}
/*
open a data base
*/
void mongoDB::open()
{
	mongocxx::instance inst{};
	mongocxx::client* client = new mongocxx::client{ mongocxx::uri{} };
	this->client = client;
	this->db = (*client)["mydb"];
	this->db["Users"];
	system("python ..\\triviaQuestions.py"); // get random questions
}

// deletes the client
void mongoDB::close()
{
	delete this->client;
}

mongoDB* mongoDB::getInstance()
{
	static mongoDB* instance = new mongoDB();
	return instance;
}

// gets random questions from the database
std::list<Question> mongoDB::getQuestions(int questionsNum)
{
	int id = 0;
	int i = 0;
	std::list<Question> questions;
	std::vector<unsigned int> questionIds;
	auto collection = this->db["Questions"];
	bsoncxx::stdx::optional<bsoncxx::document::value> result;
	std::string answers;
	nlohmann::json answersJson;

	srand(time(NULL));
	for (i = 0; i < questionsNum; i++) // get the amount of questions needed
	{
		do // continue until you get a new question id
		{
			id = rand() % QUESTIONS_NUM;
		} while (find(questionIds.begin(), questionIds.end(), id) != questionIds.end());
		questionIds.push_back(id);

		bsoncxx::builder::stream::document document{};
		document << "id" << id;
		result = collection.find_one(document.view()); // find question with the random id
		answers = bsoncxx::to_json(*result);
		answersJson = nlohmann::json::parse(answers);
		questions.push_back(answersJson.get<Question>()); // push back serialized question
	}

	return questions;
}

// gets a user's statistics
nlohmann::json mongoDB::getUserStatistics(std::string username)
{
	nlohmann::json userStatistics;

	bsoncxx::builder::stream::document document{};
	document << "username" << username;
	auto statisticsCol = this->db["Statistics"];
	auto search_result = statisticsCol.find_one(document.view());
	if (search_result) // if the user is in the statistics table
		userStatistics = nlohmann::json::parse(bsoncxx::to_json(*search_result));
	return userStatistics;
}

// gets the player's average answer time
double mongoDB::getPlayerAverageAnswerTime(std::string username)
{
	double avgTime = 0;
	nlohmann::json userStatistics = getUserStatistics(username);

	if (!userStatistics.is_null()) // if the user statistics were found
		avgTime = userStatistics["avg_answer_time"];
	return avgTime;
}

// gets the number of correct answers the player has
int mongoDB::getNumOfCorrectAnswers(std::string username)
{
	int correctAnswersNum = 0;
	nlohmann::json userStatistics = getUserStatistics(username);

	if (!userStatistics.is_null()) // if the user statistics were found
		correctAnswersNum = userStatistics["correct_answers"];
	return correctAnswersNum;
}

// gets the number of total answers the player has
int mongoDB::getNumOfTotalAnswers(std::string username)
{
	int totalAnswersNum = 0;
	nlohmann::json userStatistics = getUserStatistics(username);

	if (!userStatistics.is_null()) // if the user statistics were found
		totalAnswersNum = userStatistics["total_answers"];
	return totalAnswersNum;
}

//gets the number of games the player has played
int mongoDB::getNumOfPlayerGames(std::string username)
{
	int gamesPlayedNum = 0;
	nlohmann::json userStatistics = getUserStatistics(username);

	if (!userStatistics.is_null()) // if the user statistics were found
		gamesPlayedNum = userStatistics["games_played"];
	return gamesPlayedNum;
}

//gets the score of the player 
int mongoDB::getScore(std::string username)
{
	int score = 0;
	nlohmann::json userStatistics = getUserStatistics(username);

	if (!userStatistics.is_null()) // if the user statistics were found
		score = userStatistics["score"];
	return score;
}

// calculate a player's high score and update it in the database
void mongoDB::updateHighScore(std::string username)
{
	int score = 0;
	const int QUESTIONS_PER_GAME = 10;
	double avgCorrectAnswers = (double)getNumOfCorrectAnswers(username) / (QUESTIONS_PER_GAME * getNumOfPlayerGames(username));
	auto statisticsCol = this->db["Statistics"];

	// the formula for the score : 5000(0.2 + avgCorrectAnswers)/(0.5 + (log(avgTime + 1)+1)/10)
	score = 5000 * (0.2 + avgCorrectAnswers) / (0.5 + (log10(getPlayerAverageAnswerTime(username) + 1) + 1) / 10.0);

	statisticsCol.update_one(make_document(kvp("username", username)), make_document(kvp("$set", make_document(kvp("score", score)))));
}

//gets the highscores of all players
std::vector<std::string> mongoDB::getHighScores()
{
	std::vector<std::string> highscores;
	nlohmann::json userJson;
	auto statisticsCol = this->db["Statistics"];
	auto order = mongocxx::options::find{}.sort(make_document(kvp("score", -1))); // sort by top scores
	auto cursor = statisticsCol.find({}, order);

	for (auto player : cursor) {
		userJson = nlohmann::json::parse(bsoncxx::to_json(player));
		highscores.push_back(userJson["username"].dump() + ": " + std::to_string(userJson["score"].get<int>()));
	}

	return highscores;
}
