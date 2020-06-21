using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Client
{
    class Responses
    {
        public class Response
        {
            public int Status { get; set; }
        }
        public class LoginResponse : Response
        {
        }
        public class SignupResponse : Response
        { 
        }
    }
}
