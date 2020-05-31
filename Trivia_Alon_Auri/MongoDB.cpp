#include "MongoDB.h"
#include <iostream>
#include "json.hpp"
#include <ctime>

/*
check if user name exist in db
*/
bool mongoDB::doesUserExist(std::string username)
{
	bsoncxx::builder::stream::document document{};
	document << "username" << username;
	auto search_result = this->db["User"].find_one(document.view());
	return (bool)search_result;
}
/*
check if user name much password
*/
bool mongoDB::doesPasswordMatch(std::string username, std::string password)
{
	bsoncxx::builder::stream::document document{};
	document << "username" << username << "password" << password;
	auto search_result = this->db["User"].find_one(document.view());
	return (bool)search_result;
}

/*
add new user to the data base
*/
bool mongoDB::addNewUser(std::string username, std::string password, std::string mail, std::string address, std::string phone_number, std::string birthday)
{

	if (!this->doesUserExist(username))
	{
		bsoncxx::builder::stream::document document{};
		document << "username" << username << "password" << password << "mail" << mail << "address" << address << "phone_number" << phone_number << "birthday" << birthday;
		auto collection = this->db["User"];
		collection.insert_one(document.view());
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
	this->db["User"];
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
		} 
		while (find(questionIds.begin(), questionIds.end(), id) != questionIds.end()); 
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
