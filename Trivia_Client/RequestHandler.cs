using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia_Client
{
    class RequestHandler
    {
        private static void HandleRequest(Requests.Request request, Form form)
        {
            Responses.ResponseInfo response = Communicator.sendRequest(Serializer.SerializeRequest(request));
            ResponseHandler.HandelResponse(response, form);
        }
        public static void Signup(String username, String password, String email, String phone, String address, String birthdate, Form form)
        {
            Requests.SignupRequest request = new Requests.SignupRequest { Username = username, Password = password, PhoneNumber = phone,
                                                                          Email = email, Address = address , BirthDate = birthdate};
            HandleRequest(request, form);
        }
        public static void Login(String username, String password , Form form)
        {
            Requests.LoginRequest request = new Requests.LoginRequest { Username = username, Password = password };
            HandleRequest(request, form);
        }
    }
}
