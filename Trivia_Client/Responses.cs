using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Trivia_Client
{
    class Responses
    {
        public class Response
        {
        }
        public class LoginResponse : Response
        {
            public int Status { get; set; }
        }
        public class SignupResponse : Response
        {
            public int Status { get; set; }
        }
        public class ErrorResponse : Response
        {
            public String Message { get; set; }
        }
        public class LogoutResponse : Response
        { 
            public int Status { get; set; }
        }
        public class GetStatisticsResponse : Response
        {
            public int Status { get; set; }
            public List<String> HighScores { get; set; }
            public String Statistics { get; set; }
        }
        public class JoinRoomResponse : Response
        { 
            public int Status { get; set; }
        }
        public class LeaveRoomResponse : Response
        { 
            public int Status { get; set; }
        }
        public class CloseRoomResponse : Response
        { 
            public int Status { get; set; }
        }
        public class CreateRoomResponse : Response
        { 
            public int Status { get; set; }
        }
        public class GetRoomsResponse : Response
        {
            public List<RoomData> Rooms { get; set; }
            public int Status { get; set; }
        }
        public class GetPlayersInRoomResponse : Response
        { 
            public int Status { get; set; }
            public List<string> Players { get; set; }
        }
        public class GetRoomStateResponse : Response
        {
            public int Status { get; set; }
            public bool HasGameBegin { set; get; }
            public List<string> Players { get; set; }
            public int QuestionCount { get; set; }
            public int AnswerTimeout { get; set; }
        }

        public class ResponseInfo
        {
            public byte[] Buffer { get; set; }
            public int Code { get; set; }
        }
        public class RoomData
        {
            private int id { get; set; }
            private string name { get; set; }
            private int maxPlayers { get; set; }
            private int numOfQuestionsInGame { get; set; }
            private int timePerQuestion { get; set; }
            private int isActive { get; set; }
            




        }


    }
}
