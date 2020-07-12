#include "Game.h"
#include "MongoDB.cpp"

Question Game::getQuestionForUser(LoggedUser user)
{
	Question questionToReturn = m_questions[m_players[user].currentQuestion];
	return questionToReturn;
}

unsigned int Game::submitAnswer(LoggedUser user, std::string answer)
{
	int answerId = m_questions[m_players[user].currentQuestion].getCorrectAnswerId();
	
	if (answer == m_questions[m_players[user].currentQuestion].getCorrectAnswer())
	{
		m_players[user].correctAnswerCount++;
	}
	else
	{
		m_players[user].wrongAnswerCount++;
	}
	m_players[user].currentQuestion++;
	return answerId;
}

void Game::removePlayer(LoggedUser user)
{
	GameData data = this->m_players[user];
	this->m_players.erase(user);

	getPlayerAverageAnswerTime();
}

