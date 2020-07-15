#include "StatisticsManager.h"
#include "json.hpp"

using nlohmann::json;

// gets the top 5 players in the leaderboard
std::vector<std::string> StatisticsManager::getTopPlayers()
{
	std::vector<std::string> highscores = this->m_database->getHighScores();
	std::vector<std::string> top5Highscores;
	auto it = highscores.begin();
	for (it = highscores.begin(); it != highscores.end(); it++)
	{
		if (top5Highscores.size() < 5)
			top5Highscores.push_back(*it);
	}
	return top5Highscores;
}

// gets the user's statistics
std::string StatisticsManager::getUserStats(std::string username)
{
	json userStats = json{ {"avg_answer_time", this->m_database->getPlayerAverageAnswerTime(username)},
						   {"correct_answers", this->m_database->getNumOfCorrectAnswers(username)},
						   {"total_answers", this->m_database->getNumOfTotalAnswers(username)},
						   {"games_played", this->m_database->getNumOfPlayerGames(username)},
						   {"score", this->m_database->getScore(username)} };
	return userStats.dump();
}

StatisticsManager& StatisticsManager::getInstance(IDatabase* database)
{
	static StatisticsManager instance(database);
	return instance;
}


