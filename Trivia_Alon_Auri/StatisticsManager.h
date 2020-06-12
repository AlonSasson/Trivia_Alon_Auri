#pragma once
#include "IDatabase.h"
#include <string>
#include <vector>

class StatisticsManager
{
private:
	IDatabase* m_database;

	StatisticsManager(IDatabase* database) { this->m_database = database;}
public:
	static StatisticsManager& getInstance(IDatabase* database);
	StatisticsManager(StatisticsManager const&) = delete;
	void operator=(StatisticsManager const&) = delete;

	std::vector<std::string> getTopPlayers();
	std::string getUserStats(std::string username);
};