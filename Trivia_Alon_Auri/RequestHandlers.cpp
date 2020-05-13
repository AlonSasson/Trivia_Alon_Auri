#include "RequestHandlers.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

/*
check if the request is relevant - the id of the request much to the login id
*/
bool LoginRequestHandler::isRequestRelevant(RequestInfo respone)
{
	if (respone.id == LOGIN_ID || respone.id == SIGN_UP_ID)
	{
		return true;
	}
	return false;
}
/*
handle the login request from client
*/
RequestResult LoginRequestHandler::handleRequest(RequestInfo respone)
{
	RequestResult packetToReturn;

	if (isRequestRelevant(respone))
	{
		if (respone.id == LOGIN_ID)
		{
			std::cout << respone.buffer;
			LoginResponse respone;
			respone.status = 1;
			packetToReturn.respone = JsonResponsePacketSerializer::serializeResponse(respone);
		}
		else if(respone.id == SIGN_UP_ID)
		{
			std::cout << respone.buffer;
			SignupResponse respone;
			respone.status = 1;
			packetToReturn.respone = JsonResponsePacketSerializer::serializeResponse(respone);
		}
	}
	else
	{
		ErrorResponse respone;
		packetToReturn.respone = JsonResponsePacketSerializer::serializeResponse(respone);
	}
	packetToReturn.newHandler = nullptr;
	return packetToReturn;
}
