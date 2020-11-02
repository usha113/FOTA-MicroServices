using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Infrastructure.Helper.CustomException
{
    public class LoginFailedException : Exception
    {
        private static readonly int _code = 460;
        public static string _message = "Login Failed";
        public LoginFailedException() : base($"{_code.ToString()}: {_message}") { }
    }
}
