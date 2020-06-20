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

		public static byte[] SerializeLoginRequest(Requests.LoginRequest request)
		{ 
			String jsonStr = JsonConvert.SerializeObject(request);
			byte[] jsonBuffer = new ASCIIEncoding().GetBytes(jsonStr);
			byte[] buffer = new byte[CODE_SIZE + LEN_SIZE + jsonBuffer.Length];

			buffer[0] = (byte)codeId.LOGIN;
			Array.Copy(BitConverter.GetBytes(jsonBuffer.Length), 0, buffer, CODE_SIZE, LEN_SIZE);
			Array.Reverse(buffer, CODE_SIZE, LEN_SIZE); // convert to big indian
			Array.Copy(jsonBuffer, 0, buffer, CODE_SIZE + LEN_SIZE, jsonBuffer.Length);

			return buffer;
		}
		public static byte[] SerializeSignupRequest(Requests.SignupRequest request)
		{
			String jsonStr = JsonConvert.SerializeObject(request);
			byte[] jsonBuffer = new ASCIIEncoding().GetBytes(jsonStr);
			byte[] buffer = new byte[CODE_SIZE + LEN_SIZE + jsonBuffer.Length];

			buffer[0] = (byte)codeId.SIGNUP;
			Array.Copy(BitConverter.GetBytes(jsonBuffer.Length), 0, buffer, CODE_SIZE, LEN_SIZE);
			Array.Reverse(buffer, CODE_SIZE, LEN_SIZE); // convert to big indian
			Array.Copy(jsonBuffer, 0, buffer, CODE_SIZE + LEN_SIZE, jsonBuffer.Length);

			return buffer;
		}
	}
}
