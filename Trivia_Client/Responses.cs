using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Client
{
    class Responses
    {
        public class LoginResponse 
        {
            public int status { get; set; }
        }
        public class SignupResponse
        {
            public int status { get; set; }
        }
    }
}
