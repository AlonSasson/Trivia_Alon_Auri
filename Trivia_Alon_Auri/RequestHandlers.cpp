#include "RequestHandlers.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

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
			LoginRequest loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(request.buffer);
			std::cout << "username: " << loginRequest.username << " password: " << loginRequest.password << std::endl;
			LoginResponse response;
			response.status = 1;
			packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(response);
		}
		else if(request.id == SIGN_UP_ID)
		{
			SignupRequest signupRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(request.buffer);
			std::cout << "username: " << signupRequest.username << " password: " << signupRequest.password << " email: " << signupRequest.email << std::endl;
			SignupResponse response;
			response.status = 1;
			packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(response);
		}
	}
	else
	{
		ErrorResponse response;
		response.message = "Error, couldn't read request";
		packetToReturn.response = JsonResponsePacketSerializer::serializeResponse(response);
	}
	packetToReturn.newHandler = new LoginRequestHandler();
	return packetToReturn;
}
