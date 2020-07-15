#include "Questions.h"

using std::vector;
using std::string;
using nlohmann::json;

void from_json(const json& j, Question& question)
{
	string answerList;
	json answersJson;
	unsigned int i = 0;

	j.at("question").get_to(question.question);
	j.at("correct_answer").get_to(question.correctAnswer);
	j.at("answers").get_to(answerList);
	answersJson = json::parse(answerList);

	for (i = 0; i < ANSWERS_NUM; i++) // copy answers to answer array
		answersJson.at(std::to_string(i)).get_to(question.answers[i]);
}
