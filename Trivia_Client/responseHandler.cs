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
            LOGIN_ID 
        }
        private enum ResultCodes { 
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

        /*
         *  handel the response from server 
        */
        public static void HandelResponse(Responses.ResponseInfo response, Form form)
        {
            switch(response.Code)
            {
                case (int)Codes.ERROR_MSG_ID:
                    Responses.ErrorResponse error = Deserializer.DeserialiseResponse<ErrorResponse>(response.Buffer);
                   ((SignupMenu)form).showErrorBox(error.Message, false);

                    break;
                case (int)Codes.SIGN_UP_ID:
                    Signup(Deserializer.DeserialiseResponse<SignupResponse>(response.Buffer) , form);
                    break;       
                case (int)Codes.LOGIN_ID:   
                    Login(Deserializer.DeserialiseResponse<LoginResponse>(response.Buffer), form);
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
                    break;
            }
            ((SignupMenu)form).showErrorBox(error, userError) ;

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
        }
          
    }

}
