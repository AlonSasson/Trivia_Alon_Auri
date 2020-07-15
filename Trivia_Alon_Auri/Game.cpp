#include "Game.h"
#include "MongoDB.cpp"

Game::Game(std::vector<Question> questions, std::map<LoggedUser, GameData> players)
	: m_players(players) , m_questions(questions)
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

unsigned int Game::submitAnswer(LoggedUser user, std::string answer, double answerTime)
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
	m_players[user].averageAnswerTime = ((m_players[user].averageAnswerTime * m_players[user].currentQuestion) + answerTime) / (m_players[user].currentQuestion + 1);
	return answerId;
}

void Game::removePlayer(LoggedUser user)
{
	this->m_players.erase(user);
}

bool Game::operator==(const Game& other)
{
	return this->m_players == other.m_players;
}

int Game::getScore(double PlayerAverageAnswerTime, int NumOfTotalAnswers, int NumOfPlayerGames)
{
	int score = 0;
	const int QUESTIONS_PER_GAME = 10;
	double avgCorrectAnswers = (double)NumOfTotalAnswers / (QUESTIONS_PER_GAME * NumOfPlayerGames);

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
bool Game::isGameEmpty()
{
	return this->m_players.empty();
}

// gets the player game data
GameData& Game::getPlayerData(LoggedUser user)
{
	return this->m_players[user];
}





