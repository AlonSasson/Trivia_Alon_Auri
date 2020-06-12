#pragma once
#include <string>
#include <vector>
#include "json.hpp"

#define ANSWERS_NUM 4
#define QUESTIONS_NUM 50

typedef struct Question
{
	std::string question;
	std::string correctAnswer;
	std::string answers[ANSWERS_NUM];
} Question;

void from_json(const nlohmann::json& j, Question& question);
