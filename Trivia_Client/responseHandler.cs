using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Trivia_Client.Responses;

namespace Trivia_Client
{
    class responseHandler
    {
        private enum Codes
        {
            ERROR_MSG_ID = 0,
            SIGN_UP_ID,
            LOGIN_ID 
        }
        private enum resultCodes { 
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
            USER_ALREADY_CONNECTED
        }

        /*
         *  handel the response from server 
        */
        public static void handelResponse(Responses.ResponseInfo response, Form form)
        {
            switch(response.code)
            {
                case (int)Codes.ERROR_MSG_ID:
                    Responses.ErrorResponse error = Deserializer.DeserialiseResponse<ErrorResponse>(response.buffer);
                   ((SignupMenu)form).showErrorBox(error.Message, false);

                    break;
                case (int)Codes.SIGN_UP_ID:
                    Signup(Deserializer.DeserialiseResponse<SignupResponse>(response.buffer) , form);
                    break;       
                case (int)Codes.LOGIN_ID:   
                    Login(Deserializer.DeserialiseResponse<LoginResponse>(response.buffer), form);
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
                case (int)resultCodes.USERS_ALREADY_EXIST:
                    error = "User already exist";
                    userError = true;
                    break;
                case (int)resultCodes.ERROR:
                    error = "Server couldn't hande; with request";
                    break;
            }
            ((SignupMenu)form).showErrorBox(error, userError) ;

        }
        private static void Login(Responses.LoginResponse response, Form form)
        {
            String error = "";
            switch (response.Status)
            {
                case (int)resultCodes.ERROR:
                  error = "Server couldn't hande; with request";
                   break;
               
                case (int)resultCodes.USER_ALREADY_CONNECTED:
                    error = "User already connected";
                    break;
               
                case (int)resultCodes.USER_DOESNT_EXIST:
                    error = "User doesn't exist";
                    break;
                case (int)resultCodes.WRONG_DETAILS:
                    error = "Username or password incorrect";
                    break;
           }

          ((LoginMenu)form).showErrorBox(error);
        }
          
    }

}
