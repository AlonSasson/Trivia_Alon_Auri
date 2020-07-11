using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Client
{
    class Requests
    {
        public class Request
        {
        }

        public class LoginRequest : Request
        {
            public String Username { get; set; }
            public String Password { get; set; }
        }

        public class SignupRequest : Request
        {
            public String Username { get; set; }
            public String Password { get; set; }
            public String Email { get; set; }
            public String Address { get; set; }
            public String PhoneNumber { get; set; }
            public String BirthDate { get; set; }
        }

        public class GetPlayersInRoomRequest : Request
        {
            public int RoomId { get; set; }
        }

        public class JoinRoomRequest : Request
        {
            public int RoomId { get; set; }
        }

        public class CreateRoomRequest : Request
        {
            public String RoomName { get; set; }
            public int MaxUsers { get; set; }
            public int QuestionCount { get; set; }
            public int AnswerTimeout { get; set; }
        }

    }
}
