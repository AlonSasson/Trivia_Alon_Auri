#include "LoginManager.h"
#include <regex>

#define PASSWORD_REGEX "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*])[A-Za-z\\d!@#$%^&*]{8,}$"
#define EMAIL_REGEX "^(?:[a-zA-Z0-9]\\.?)*[a-zA-Z0-9]@[a-zA-Z]+(?:\\.[a-zA-Z]+)+$"
#define ADDRESS_REGEX "^\\([a-zA-Z]+, \\d+, [a-zA-Z]+\\)$"
#define PHONE_REGEX "^0\\d{1,2}-\\d+$"
#define BIRTHDAY_REGEX "^(?:(?:\\d{2}\\.){2}|(?:\\d{2}\\/){2})\\d{4}$"

enum resultCodes{ERROR, OK, PASSWORD_INVALID, EMAIL_INVALID, ADDRESS_INVALID, PHONE_INVALID, BIRTHDAY_INVALID};


using std::regex;

// logs in a user
unsigned int LoginManager::login(std::string username, std::string password)
{
	return OK;
}

// signs up a user
unsigned int LoginManager::signup(std::string username, std::string password, std::string email, std::string address, std::string phoneNumber, std::string birthDate)
{
	int infoValidationResult = validateInfo(password, email, address, phoneNumber, birthDate);

	if (infoValidationResult != OK) // if the info wasn't valid
		return infoValidationResult;


	return OK;
}

// logs out a user
unsigned int LoginManager::logout(std::string username)
{
	return OK;
}

// uses regex checks to make sure the signup info is valid, returns OK if all are valid
unsigned int LoginManager::validateInfo(std::string password, std::string email, std::string address, std::string phoneNumber, std::string birthDate)
{
	regex passwordRegex(PASSWORD_REGEX);
	regex emailRegex(EMAIL_REGEX);
	regex addressRegex(ADDRESS_REGEX);
	regex phoneRegex(PHONE_REGEX);
	regex birthdayRegex(BIRTHDAY_REGEX);

	if (!regex_match(password, passwordRegex)) // if the password is invalid
		return PASSWORD_INVALID;
	else if (!regex_match(email, emailRegex)) // if the email is invalid
		return EMAIL_INVALID;
	else if (!regex_match(address, addressRegex)) // if the address is invalid
		return ADDRESS_INVALID;
	else if (!regex_match(phoneNumber, phoneRegex)) // if the phone number is invalid
		return PHONE_INVALID;
	else if (!regex_match(birthDate, birthdayRegex)) // if the birthday is invalid
		return BIRTHDAY_INVALID;

	return OK;
}
