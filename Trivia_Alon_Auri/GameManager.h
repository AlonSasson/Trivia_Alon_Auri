#pragma once
#include "IDatabase.h"
#include "Game.h"
#include "Room.h"
class GameManager
{
private:
	IDatabase *m_database;
	std::vector<Game> m_games;
	GameManager(IDatabase* database) { m_database = database; }
public:
	static GameManager& getInstance(IDatabase* database);

	GameManager(GameManager const&) = delete;
	void createGame(Room room);
	void deleteGame(Game game);
	void removePlayerInGame(LoggedUser user, Game game);
	Game& getGameForPlayer(std::string username);
};