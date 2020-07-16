using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Trivia_Client.Responses;

namespace Trivia_Client
{
    class ResponseHandler
    {
        private enum Codes
        {
            ERROR_MSG_ID = 0,
            SIGN_UP_ID,
            LOGIN_ID,
            LOGOUT,
            GET_ROOMS,
            GET_PLAYERS_IN_ROOM,
            JOIN_ROOM,
            CREATE_ROOM,
            GET_STATISTICS,
            CLOSE_ROOM,
            START_GAME,
            GET_ROOM_STATE,
            LEAVE_ROOM,
            LEAVE_GAME,
            GET_QUESTION,
            SUBMIT_ANSWER,
            GET_GAME_RESULTS

        }
        private enum ResultCodes
        {
            ERROR = 0,
            OK,
            PASSWORD_INVALID,
            EMAIL_INVALID,
            ADDRESS_INVALID,
            PHONE_INVALID,
            BIRTHDAY_INVALID,
            WRONG_DETAILS,
            USERS_ALREADY_EXIST,
            USER_DOESNT_EXIST,
            USER_ALREADY_CONNECTED,
            USERNAME_NOT_VALID
        }
        private enum RoomState
        {

            ROOM_WAITING_FOR_PLAYERS = 0,
            ROOM_WHILE_GAME,
            ROOM_GAME_ENDED
        }
        /*
         *  handel the response from server 
        */
        public static void HandelResponse(Responses.ResponseInfo response, Form form)
        {
            switch (response.Code)
            {
                case (int)Codes.ERROR_MSG_ID:
                    Responses.ErrorResponse error = Deserializer.DeserialiseResponse<ErrorResponse>(response.Buffer);
                    if (typeof(SignupMenu).IsInstanceOfType(form))
                    {
                        ((SignupMenu)form).showErrorBox(error.Message, false);
                    }
                    else if (typeof(LoginMenu).IsInstanceOfType(form))
                    {
                        ((LoginMenu)form).showErrorBox(error.Message);
                    }
                    else if (typeof(RoomListMenu).IsInstanceOfType(form))
                    {
                        ((RoomListMenu)form).showErrorBox(error.Message);
                    }
                    else if (typeof(RoomMenu).IsInstanceOfType(form))
                    {
                        ((RoomMenu)form).showErrorBox(error.Message);
                    }
                    break;
                case (int)Codes.SIGN_UP_ID:
                    Signup(Deserializer.DeserialiseResponse<SignupResponse>(response.Buffer), form);
                    break;
                case (int)Codes.LOGIN_ID:
                    Login(Deserializer.DeserialiseResponse<LoginResponse>(response.Buffer), form);
                    break;
                case (int)Codes.LOGOUT:
                    Logout(Deserializer.DeserialiseResponse<LogoutResponse>(response.Buffer), form);
                    break;
                case (int)Codes.JOIN_ROOM:
                    JoinRoom(Deserializer.DeserialiseResponse<JoinRoomResponse>(response.Buffer), form);
                    break;
                case (int)Codes.LEAVE_ROOM:
                    LeaveRoom(Deserializer.DeserialiseResponse<LeaveRoomResponse>(response.Buffer), form);
                    break;
                case (int)Codes.CREATE_ROOM:
                    CreateRoom(Deserializer.DeserialiseResponse<CreateRoomResponse>(response.Buffer), form);
                    break;
                case (int)Codes.GET_STATISTICS:
                    GetStatistics(Deserializer.DeserialiseResponse<GetStatisticsResponse>(response.Buffer), form);
                    break;
                case (int)Codes.CLOSE_ROOM:
                    CloseRoom(Deserializer.DeserialiseResponse<CloseRoomResponse>(response.Buffer), form);
                    break;
                case (int)Codes.START_GAME:
                    StartGame(Deserializer.DeserialiseResponse<StartGameResponse>(response.Buffer), form);
                    break;
                case (int)Codes.GET_PLAYERS_IN_ROOM:
                    GetPlayersInRoom(Deserializer.DeserialiseResponse<GetPlayersInRoomResponse>(response.Buffer), form);
                    break;
                case (int)Codes.GET_ROOM_STATE:
                    GetRoomState(Deserializer.DeserialiseResponse<GetRoomStateResponse>(response.Buffer), form);
                    break;
                case (int)Codes.GET_ROOMS:
                    GetRooms(Deserializer.DeserialiseResponse<GetRoomsResponse>(response.Buffer), form);
                    break;
                case (int)Codes.LEAVE_GAME:
                    LeaveGame(Deserializer.DeserialiseResponse<LeaveGameResponse>(response.Buffer), form);
                    break;
                case (int)Codes.GET_QUESTION:
                    GetQuestion(Deserializer.DeserialiseResponse<GetQuestionResponse>(response.Buffer), form);
                    break;
                case (int)Codes.SUBMIT_ANSWER:
                    SubmitAnswer(Deserializer.DeserialiseResponse<SubmitAnswerResponse>(response.Buffer), form);
                    break;
                case (int)Codes.GET_GAME_RESULTS:
                    GetGameResults(Deserializer.DeserialiseResponse<GetGameResultsResponse>(response.Buffer), form);
                    break;

                default: break;
            }
        }

        private static void Signup(Responses.SignupResponse response, Form form)
        {
            String error = "";
            bool userError = false;
            switch (response.Status)
            {
                case (int)ResultCodes.USERS_ALREADY_EXIST:
                    error = "User already exist";
                    userError = true;
                    break;
                case (int)ResultCodes.ERROR:
                    error = "Server couldn't hande; with request";
                    break;
                case (int)ResultCodes.USERNAME_NOT_VALID:
                    error = "Username isn't valid";
                    userError = true;
                    break;
            }
            ((SignupMenu)form).showErrorBox(error, userError);
            if (error == "")
            {
                ((SignupMenu)form).SignupWorked();
            }

        }
        private static void Login(Responses.LoginResponse response, Form form)
        {
            String error = "";
            switch (response.Status)
            {
                case (int)ResultCodes.ERROR:
                    error = "Server couldn't hande; with request";
                    break;

                case (int)ResultCodes.USER_ALREADY_CONNECTED:
                    error = "User already connected";
                    break;

                case (int)ResultCodes.USER_DOESNT_EXIST:
                    error = "User doesn't exist";
                    break;
                case (int)ResultCodes.WRONG_DETAILS:
                    error = "Username or password incorrect";
                    break;
                case (int)ResultCodes.USERNAME_NOT_VALID:
                    error = "Username isn't valid";
                    break;

            }

          ((LoginMenu)form).showErrorBox(error);
            if (error == "")
            {
                ((LoginMenu)form).LoginWorked();
            }

        }
        private static void Logout(Responses.LogoutResponse response, Form form)
        {
            string error = "Failed to Logout";
            if (response.Status == (int)ResultCodes.OK)
            {
                ((RoomListMenu)form).LogoutWorked();
            }
            else
            {
                ((RoomListMenu)form).showErrorBox(error);
            }
        }
        private static void JoinRoom(Responses.JoinRoomResponse response, Form form)
        {
            string error = "Failed to Join room";
            if (response.Status == (int)RoomState.ROOM_WAITING_FOR_PLAYERS)
            {
                ((RoomListMenu)form).JoinRoomWorked();
            }
            else
            {
                ((RoomListMenu)form).showErrorBox(error);
            }
        }
        private static void LeaveRoom(Responses.LeaveRoomResponse respnse, Form form)
        {
            string error = "Failed to Leave room";
            if (respnse.Status == (int)ResultCodes.OK)
            {
                if (typeof(RoomMenu).IsInstanceOfType(form))
                    ((RoomMenu)form).leaveRoomWorked();
            }
            else
            {
                ((RoomMenu)form).showErrorBox(error);
            }
        }
        private static void CreateRoom(Responses.CreateRoomResponse response, Form form)
        {
            string error = "Failed to Create room";
            if (response.Status == (int)ResultCodes.OK)
            {
                ((CreateRoomMenu)form).createRoomWorked();
            }
            else
            {
                ((CreateRoomMenu)form).showErrorBox(error);
            }
        }
        private static void GetStatistics(Responses.GetStatisticsResponse response, Form form)
        {
            if (response.Status == (int)ResultCodes.OK)
            {
                ((StatisticsMenu)form).ShowScores(response.HighScores);
                ((StatisticsMenu)form).ShowStatistics(response.Statistics);
            }
        }
        private static void CloseRoom(Responses.CloseRoomResponse response, Form form)
        {
            string error = "Failed to Close room";
            if (response.Status == (int)ResultCodes.OK)
            {
                ((RoomMenu)form).leaveRoomWorked();
            }
            else
            {
                ((RoomMenu)form).showErrorBox(error);
            }
        }
        private static void StartGame(Responses.StartGameResponse response, Form form)
        {
            string error = "Failed to start game";
            if(response.Status == (int)ResultCodes.OK)
            {
                ((RoomMenu)form).StartGameWorked();
            }
            else
            {
                ((RoomMenu)form).showErrorBox(error);
            }
        }
        private static void GetPlayersInRoom(Responses.GetPlayersInRoomResponse response, Form form)
        {
            string error = "Failed to Get players in room";
            if (response.Players.Count() != 0)
            {
                ((RoomListMenu)form).ShowPlayers(response.Players);
            }
            else
            {
                ((RoomListMenu)form).showErrorBox(error);
            }
        }
        private static void GetRoomState(Responses.GetRoomStateResponse response, Form form)
        {
            string error = "Failed to Get room state";

            if (response.Status == (int)ResultCodes.OK)
            {
                if (response.HasGameBegun == (int)RoomState.ROOM_WHILE_GAME)
                {
                    RequestHandler.StartGame(form);
                }
                if (response.HasGameBegun == (int)RoomState.ROOM_GAME_ENDED)
                {
                    RequestHandler.LeaveRoom(form);
                }
                else
                {
                    ((RoomMenu)form).addPlayers(response.Players);
                    ((RoomMenu)form).SetParameters(response.AnswerTimeout.ToString());
                }
            }
            else
            {
                ((RoomMenu)form).showErrorBox(error);
            }
        }
        private static void GetRooms(Responses.GetRoomsResponse response, Form form)
        {
            string error = "No rooms were found";
            List<String> rooms = new List<string>();
            if (response.Status == (int)ResultCodes.OK)
            {
                foreach (Object room in response.Rooms)
                    rooms.Add(((RoomData)room).Name);
                if (typeof(RoomListMenu).IsInstanceOfType(form))
                    ((RoomListMenu)form).addRooms(rooms);
            }
            else
            {
                ((RoomListMenu)form).ClearList();
                ((RoomListMenu)form).showErrorBox(error);
            }
        }
        private static void LeaveGame(Responses.LeaveGameResponse response, Form form)
        {
            if (response.Status == (int)ResultCodes.OK)
            {
                if (typeof(GameMenu).IsInstanceOfType(form))
                {
                    ((GameMenu)form).QuitWorked();
                }
                 else if (typeof(ResultMenu).IsInstanceOfType(form))
                    ((ResultMenu)form).QuitWorked();
            }
        }
        private static void GetQuestion(Responses.GetQuestionResponse response, Form form)
        {
            if (response.Status == (int)ResultCodes.OK)
            {
                ((GameMenu)form).UpdateQuestion(response.Question, response.Answers);
            }
            else // if there are no more questions, the game ended
            {
                ((GameMenu)form).NeedResults();
            }
        }
        private static void SubmitAnswer(Responses.SubmitAnswerResponse response, Form form)
        {
            if (response.Status == (int)ResultCodes.OK)
            {
                ((GameMenu)form).UpdateCorrectAnswer(response.CorrectAnswerId);
            }
        }
        private static void GetGameResults(Responses.GetGameResultsResponse response, Form form)
        {
            List<string> results = new List<string>();
            string resultStr;
            if (response.Status == (int)ResultCodes.OK)
            {

                foreach(PlayerResults result in response.Results)
                {
                    result.AverageAnswerTime = Convert.ToDouble(result.AverageAnswerTime.ToString("0.00"));
                    resultStr = result.Username + "\t   " + result.CorrectAnswerCount + "\t\t" + result.WrongAnswerCount + "\t   " + result.AverageAnswerTime + "\t\t" + result.Score;
                    results.Add(resultStr);
                }
                ((ResultMenu)form).UpdateResults(results);
            }
        }

    }

}
