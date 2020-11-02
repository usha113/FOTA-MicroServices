using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Infrastructure.Helper.CustomException
{
    public class UserAlreadyExistsException : Exception
    {
        private static readonly int _code = 463;
        public static string _message = "User Account exists";

        public UserAlreadyExistsException() : base($"{_code.ToString()}: {_message}") { }
    }
}
