#include "Game.h"
#include "MongoDB.cpp"

Game::Game(std::vector<Question> questions, std::map<LoggedUser, GameData> players)
	: m_players(players) , m_questions(questions)
{
}

Question Game::getQuestionForUser(LoggedUser user)
{
	Question questionToReturn = m_questions[m_players[user].currentQuestion];
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

void Game::removePlayer(LoggedUser user, IDatabase* database)
{
	GameData data = this->m_players[user];
	this->m_players.erase(user);

	int NumOfCorrectAnswers = database->getNumOfCorrectAnswers(user.getUserName()) + data.correctAnswerCount;
	int NumOfPlayerGames = database->getNumOfPlayerGames(user.getUserName()) + 1;
	int NumOfTotalAnswers = database->getNumOfTotalAnswers(user.getUserName()) + 10;
	double PlayerAverageAnswerTime = (database->getPlayerAverageAnswerTime(user.getUserName()) * (NumOfPlayerGames -1) + data.averageAnswerTime) / NumOfPlayerGames;
	
	database->updateStaticsDB(user.getUserName(), PlayerAverageAnswerTime, NumOfCorrectAnswers, NumOfTotalAnswers, NumOfPlayerGames, getScore(PlayerAverageAnswerTime, NumOfTotalAnswers, NumOfPlayerGames));
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





