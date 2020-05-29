#include "RequestHandlers.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

#define OK 1
// logs in a user 
RequestResult LoginRequestHandler::login(RequestInfo request)
{
	RequestResult loginResult;
	LoginResponse response; 
	LoginRequest loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(request.buffer);

	response.status = m_loginManager.login(loginRequest.username, loginRequest.password); // get status from login into database
	loginResult.response = JsonResponsePacketSerializer::serializeResponse(response);

	if (response.status == OK)
		loginResult.newHandler = m_handlerFactory.createMenuRequestHandler(); // move on to next state
	else
		loginResult.newHandler = m_handlerFactory.createLoginRequestHandler(); // stay in the same state
	return loginResult;
}

// signs up a user
RequestResult LoginRequestHandler::signup(RequestInfo request)
{
	RequestResult signupResult;
	SignupResponse response; 
	SignupRequest signupRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(request.buffer);
	
	response.status = m_loginManager.signup(signupRequest.username, signupRequest.password, signupRequest.email,
												  signupRequest.address, signupRequest.phoneNumber, signupRequest.birthDate); // get status from signup into database
	signupResult.response = JsonResponsePacketSerializer::serializeResponse(response);

	if (response.status == OK)
		signupResult.newHandler = m_handlerFactory.createMenuRequestHandler(); // move on to next state
	else
		signupResult.newHandler =m_handlerFactory.createLoginRequestHandler(); // stay in the same state
	return signupResult;
}

/*
check if the request is relevant - the id of the request much to the login id
*/
bool LoginRequestHandler::isRequestRelevant(RequestInfo request)
{
	return request.id == LOGIN_ID || request.id == SIGN_UP_ID;
}
/*
handle the login request from client
*/
RequestResult LoginRequestHandler::handleRequest(RequestInfo request)
{
	RequestResult packetToReturn;

	if (isRequestRelevant(request))
	{
		if (request.id == LOGIN_ID)
		{
			packetToReturn = login(request);
		}
		else if(request.id == SIGN_UP_ID)
		{
			packetToReturn = signup(request);
		}
	}
	else
	{
		ErrorResponse response;
		response.message = "Error, couldn't read request";
		packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(response);
		packetToReturn.newHandler = this->m_handlerFactory.createLoginRequestHandler(); // stay in the same state
	}	
	return packetToReturn;
}

LoginRequestHandler::LoginRequestHandler(RequestHandlerFactory& handlerFactory):
	m_handlerFactory(handlerFactory), m_loginManager(handlerFactory.getLoginManager())
{
}


bool MenuRequestHandler::isRequestRelevant(RequestInfo request)
{
	return false;
}

RequestResult MenuRequestHandler::handleRequest(RequestInfo request)
{
	return RequestResult();
}
