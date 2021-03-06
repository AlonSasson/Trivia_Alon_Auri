#include "GameManager.h"
#include <exception>

GameManager& GameManager::getInstance(IDatabase* database)
{
	static GameManager instance(database);
	return instance;
}
/*
create game
*/
void GameManager::createGame(Room room)
{
	std::map<LoggedUser, GameData> players;
	GameData data;
	std::string playerName;
	data.averageAnswerTime = 0;
	data.correctAnswerCount = 0;
	data.currentQuestion = 0;
	data.wrongAnswerCount = 0;
	std::vector<std::string> usersInRooms = room.getAllUsers();
	for (auto player = usersInRooms.begin(); player != usersInRooms.end(); player++)
	{
		players.insert(std::pair<LoggedUser, GameData>(LoggedUser(*player), data));
	}
	m_games.push_back(Game(m_database->getQuestions(10), players));
}
/*
delete game
*/
void GameManager::deleteGame(Game game)
{
	for (auto it = m_games.begin(); it != m_games.end(); it++)
	{
		if (*it == game)
		{
			this->m_games.erase(it);
			break;
		}
	}
}

void GameManager::removePlayerInGame(LoggedUser user, Game& game)
{
	GameData data = game.getPlayerData(user);

	game.removePlayer(user);

	int NumOfCorrectAnswers = this->m_database->getNumOfCorrectAnswers(user.getUserName()) + data.correctAnswerCount;
	int NumOfPlayerGames = this->m_database->getNumOfPlayerGames(user.getUserName()) + 1;
	int NumOfTotalAnswers = this->m_database->getNumOfTotalAnswers(user.getUserName()) + 10;
	double PlayerAverageAnswerTime = (this->m_database->getPlayerAverageAnswerTime(user.getUserName()) * (NumOfPlayerGames - 1) + data.averageAnswerTime) / NumOfPlayerGames;

	this->m_database->updateStaticsDB(user.getUserName(), PlayerAverageAnswerTime, NumOfCorrectAnswers, NumOfTotalAnswers, NumOfPlayerGames, Game::getScore(PlayerAverageAnswerTime, NumOfCorrectAnswers, NumOfPlayerGames));
}

// gets the game which the player is in
Game& GameManager::getGameForPlayer(std::string username)
{

	for (int i = 0; i < m_games.size(); i++)
	{
		if (m_games[i].isPlayerInGame(username)) // if the player is in this game
		{
			return m_games[i];
		}
	}
	throw std::exception("Game Not Found");
}
