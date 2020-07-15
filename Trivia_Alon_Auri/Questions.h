#pragma once
#include <string>
#include <vector>
#include "json.hpp"

#define ANSWERS_NUM 4
#define QUESTIONS_NUM 50


class Question
{
private:
	std::string m_question;
	std::string m_correctAnswer;
	std::vector<std::string> m_possibleAnswers;

public:
	void setQuestion(std::string question);
	void setCorrectAnswer(std::string correctAnswer);
	void setAnswers(std::vector<std::string> answers);
	int getCorrectAnswerId();

	std::string getQuestion();
	std::vector<std::string> getPossibleAnswers();
	std::string getCorrectAnswer();
};

void from_json(const nlohmann::json& j, Question& question);
