#include "Game.h"
#include <iostream>

Game::Game(std::vector<Question> questions, std::map<LoggedUser, GameData> players)
	: m_players(players), m_questions(questions)
{
}

Question Game::getQuestionForUser(LoggedUser user)
{
	Question questionToReturn;
	if (m_players[user].currentQuestion == m_questions.size()) // if there are no more questions
	{
		questionToReturn.setQuestion("");
		questionToReturn.setCorrectAnswer("");
		questionToReturn.setAnswers(std::vector<std::string>());
		return questionToReturn;
	}
	questionToReturn = m_questions[m_players[user].currentQuestion];
	return questionToReturn;
}

unsigned int Game::submitAnswer(LoggedUser user, unsigned int id, double answerTime)
{
	int answerId = m_questions[m_players[user].currentQuestion].getCorrectAnswerId();

	if (id == answerId)
	{
		m_players[user].correctAnswerCount++;
	}
	else
	{
		m_players[user].wrongAnswerCount++;
	}
	m_players[user].currentQuestion++;
	std::cout << ((m_players[user].averageAnswerTime * m_players[user].currentQuestion) + answerTime) / (double)(m_players[user].currentQuestion + 1);
	m_players[user].averageAnswerTime = ((m_players[user].averageAnswerTime * m_players[user].currentQuestion) + answerTime) / (double)(m_players[user].currentQuestion + 1);
	return answerId;
}

void Game::removePlayer(LoggedUser user)
{
	this->m_players.erase(user);
}

bool Game::operator==(const Game& other)
{
	auto it1 = m_players.begin();
	for (auto it2 = other.m_players.begin(); it1 != m_players.end() && it2 != other.m_players.end(); it1++, it2++)
	{
		if (it1->first.getUserName() != it2->first.getUserName())
		{
			return false;
		}
	}
	return m_players.size() == other.m_players.size();
}

int Game::getScore(double PlayerAverageAnswerTime, int numOfCorrectAnswers, int NumOfPlayerGames)
{
	int score = 0;
	const int QUESTIONS_PER_GAME = 10;
	double avgCorrectAnswers = (double)numOfCorrectAnswers / (QUESTIONS_PER_GAME * NumOfPlayerGames);

	// the formula for the score : 5000(0.2 + avgCorrectAnswers)/(0.5 + (log(avgTime + 1)+1)/10)
	score = 5000 * (0.2 + avgCorrectAnswers) / (0.5 + (log10(PlayerAverageAnswerTime + 1) + 1) / 10.0);
	return score;
}

// checks if a player is in this game
bool Game::isPlayerInGame(std::string username)
{
	for (auto it = this->m_players.begin(); it != this->m_players.end(); it++)
	{
		if (it->first.getUserName() == username) // if the player has been found
		{
			return true;
		}
	}
	return false;
}

// checks if the game has no players in it
unsigned int Game::playersInGame()
{
	return this->m_players.size();
}

// gets the player game data
GameData& Game::getPlayerData(LoggedUser user)
{
	return this->m_players[user];
}

std::vector<PlayerResults> Game::getGameResults()
{

	int i, j;
	PlayerResults temp;
	PlayerResults playerResult;
	std::vector<PlayerResults> results;

	for (auto it = m_players.begin(); it != m_players.end(); it++) // entering the ata into results
	{
		playerResult.averageAnswerTime = it->second.averageAnswerTime;
		playerResult.correctAnswerCount = it->second.correctAnswerCount;
		playerResult.wrongAnswerCount = it->second.wrongAnswerCount;
		playerResult.username = it->first.getUserName();
		playerResult.score = getScore(playerResult.averageAnswerTime, playerResult.correctAnswerCount, 1);
		results.push_back(playerResult);
	}

	for (i = 0; i < results.size() - 1; i++) // sorting the results by score
	{
		// Last i elements are already in place  
		for (j = 0; j < results.size() - i - 1; j++)
		{
			if (results[j].score > results[j + 1].score)
			{
				temp = results[j];
				results[j] = results[j + 1];
				results[j + 1] = temp;
			}
		}
	}
	return results;

}
