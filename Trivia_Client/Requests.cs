﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Client
{
    class Requests
    {
        public class LoginRequest
        {
            public String Username { get; set; }
            public String Password { get; set; }
        }

        public class SignupRequest
        {
            public String Username { get; set; }
            public String Password { get; set; }
            public String Email { get; set; }
            public String Address { get; set; }
            public String PhoneNumber { get; set; }
            public String BirthDate { get; set; }
        }

    }
}