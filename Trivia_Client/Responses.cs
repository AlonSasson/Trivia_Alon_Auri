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

        public class LeaveGameResponse : Response
        {
            public int Status { get; set; }
        }

        public class GetQuestionResponse : Response
        {
            public int Status { get; set; }
            public String Question { get; set; }
            public Dictionary<int, String> Answers { get; set; }
        }

        public class SubmitAnswerResponse : Response
        {
            public int Status { get; set; }
            public int CorrectAnswerId { get; set; }
        }

        public class GetGameResultsResponse : Response
        {
            public int Status { get; set; }
            public List<PlayerResults> Results { get; set; }
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

        public class PlayerResults
        {
            private String Username { get; set; }
            private int CorrectAnswerCount { get; set; }
            private int WrongAnswerCount { get; set; }
            private int AverageAnswerTime { get; set; }
            private int Score { get; set; }
        }


    }
}
