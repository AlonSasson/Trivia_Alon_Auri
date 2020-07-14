#include "GameManager.h"
 
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

	for (auto player = room.getAllUsers().begin();player != room.getAllUsers().end();player++)
	{
		players.insert(std::pair<LoggedUser , GameData>(LoggedUser(*player), data));
	}
	m_games.push_back(Game(m_database->getQuestions(10), players));
}
/*
delete game
*/
void GameManager::deleteGame(Game game)
{
	for (auto it = m_games.begin();it != m_games.end();it++)
	{
		if (*it == game)
		{
			this->m_games.erase(it);
			break;
		}
	}
}
