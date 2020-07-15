#include "Questions.h"
#include "LoggedUser.h"
#include "IDatabase.h"

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
	Game(std::vector<Question> questions , std::map<LoggedUser , GameData> players);
	Question getQuestionForUser(LoggedUser user);
	unsigned int submitAnswer(LoggedUser user, std::string answer, double answerTime);
	void removePlayer(LoggedUser user, IDatabase* database);
	bool operator==(const Game& other);
	int getScore(double PlayerAverageAnswerTime, int NumOfTotalAnswers, int NumOfPlayerGames);
};

