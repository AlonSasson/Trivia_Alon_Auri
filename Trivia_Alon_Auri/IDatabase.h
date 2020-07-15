#pragma once
#include <string>
#include <List>
#include "Questions.h"

class IDatabase
{
public:

	// queries
	virtual bool doesUserExist(std::string username) = 0;
	virtual bool doesPasswordMatch(std::string username , std::string password) = 0;

	// user related
	virtual bool addNewUser(std::string username, std::string password, std::string mail, std::string address, std::string phone_number, std::string birthday) = 0;

	//data base related
	virtual void open() = 0;
	virtual void close() = 0;

	// queries
	virtual std::vector<Question> getQuestions(int questionsNum) = 0;
	virtual double getPlayerAverageAnswerTime(std::string username) = 0;
	virtual int getNumOfCorrectAnswers(std::string username) = 0;
	virtual int getNumOfTotalAnswers(std::string username) = 0;
	virtual int getNumOfPlayerGames(std::string username) = 0;
	virtual int getScore(std::string username) = 0;
	virtual std::vector<std::string> getHighScores() = 0;
	virtual void updateStaticsDB(std::string username, double averegeAnswerTime, int numOfCorrectAnswers, int numOfTotalAnswers, int numOfGamesPlayed, int score) = 0;


};