using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Infrastructure.Helper.CustomException
{
    public class UserNotFoundException : Exception
    {
        private static readonly int _code = 461;
        public static string _message = "User Not Found";
        public UserNotFoundException() : base($"{_code.ToString()}: {_message}") { }
    }
}
