using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Infrastructure.Helper.CustomException
{
    public class WrongPasswordException : Exception
    {
        private static readonly int _code = 467;
        public static string _message = "Wrong Password";

        public WrongPasswordException(short failureCount) : base($"{_code.ToString()}: {_message} - {failureCount}") { }
    }
}
