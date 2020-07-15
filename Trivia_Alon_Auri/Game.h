#pragma once
#include "Questions.h"
#include "LoggedUser.h"
#include "PlayerResults.h"
#include <map>

typedef struct GameData
{
	unsigned int currentQuestion;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;
}GameData;

class Game
{
private:
	std::vector<Question> m_questions;
	std::map<LoggedUser, GameData>	m_players;

public:
	Game(std::vector<Question> questions, std::map<LoggedUser, GameData> players);
	Question getQuestionForUser(LoggedUser user);
	unsigned int submitAnswer(LoggedUser user, unsigned int id, double answerTime);
	void removePlayer(LoggedUser user);
	bool operator==(const Game& other);
	static int getScore(double PlayerAverageAnswerTime, int NumOfTotalAnswers, int NumOfPlayerGames);
	bool isPlayerInGame(std::string username);
	unsigned int playersInGame();
	GameData& getPlayerData(LoggedUser user);
	std::vector<PlayerResults> getGameResults();
};
