#include "Questions.h"

using std::vector;
using std::string;
using nlohmann::json;

void from_json(const json& j, Question& question)
{
	string answerList;
	json answersJson;
	unsigned int i = 0;

	question.setQuestion(j.at("question").get<std::string>());
	question.setCorrectAnswer(j.at("correct_answer").get<std::string>());
	question.setAnswers(j.at("answers").get<std::vector<std::string>>());
	
}

void Question::setQuestion(std::string question)
{
	this->m_question = question;
}

void Question::setCorrectAnswer(std::string correctAnswer)
{
	this->m_correctAnswer = correctAnswer;
}

void Question::setAnswers(std::vector<std::string> answers)
{
	this->m_possibleAnswers = answers;
}

	for (i = 0; i < ANSWERS_NUM; i++) // copy answers to answer array
		answersJson.at(std::to_string(i)).get_to(question.answers[i]);
}
