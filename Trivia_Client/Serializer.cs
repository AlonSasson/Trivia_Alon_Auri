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
		enum codeId
		{
			SIGNUP = 1,
			LOGIN
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
