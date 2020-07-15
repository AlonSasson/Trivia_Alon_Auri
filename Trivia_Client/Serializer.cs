using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Client
{
    class Serializer
    {
		public enum codeId
		{
			LOGOUT = 0,
			SIGNUP,
			LOGIN,
			GET_ROOMS,
			GET_PLAYERS_IN_ROOM,
			GET_STATISTICS,
			JOIN_ROOM,
			CREATE_ROOM,
			CLOSE_ROOM,
			START_GAME,
			GET_ROOM_STATE,
			LEAVE_ROOM,
			LEAVE_GAME,
			GET_QUESTION,
			SUBMIT_ANSWER,
			GET_GAME_RESULTS
		};
		public const int CODE_SIZE = 1;
		public const int LEN_SIZE = 4;

		//gets the correct code id based on the given request
		private static codeId GetRequestCodeId(Requests.Request request)
		{
			if (request.GetType() == typeof(Requests.SignupRequest))
				return codeId.SIGNUP;
			else if (request.GetType() == typeof(Requests.LoginRequest))
				return codeId.LOGIN;
			else if (request.GetType() == typeof(Requests.GetPlayersInRoomRequest))
				return codeId.GET_PLAYERS_IN_ROOM;
			else if (request.GetType() == typeof(Requests.JoinRoomRequest))
				return codeId.JOIN_ROOM;
			else if (request.GetType() == typeof(Requests.CreateRoomRequest))
				return codeId.CREATE_ROOM;
			else if (request.GetType() == typeof(Requests.SubmitAnswerRequest))
				return codeId.SUBMIT_ANSWER;
			else
				throw new Exception("Request type is invalid.");
		}

		
		// serializes a request into a byte array
		public static byte[] SerializeRequest(Requests.Request request)
		{ 
			String jsonStr = JsonConvert.SerializeObject(request);
			byte[] jsonBuffer = new ASCIIEncoding().GetBytes(jsonStr);
			byte[] buffer = new byte[CODE_SIZE + LEN_SIZE + jsonBuffer.Length];

			buffer[0] = (byte)GetRequestCodeId(request);
			Array.Copy(BitConverter.GetBytes(jsonBuffer.Length), 0, buffer, CODE_SIZE, LEN_SIZE);
			Array.Reverse(buffer, CODE_SIZE, LEN_SIZE); // convert to big indian
			Array.Copy(jsonBuffer, 0, buffer, CODE_SIZE + LEN_SIZE, jsonBuffer.Length);

			return buffer;
		}
	}
}
