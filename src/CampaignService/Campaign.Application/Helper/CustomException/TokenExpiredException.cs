using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Infrastructure.Helper.CustomException
{
    public class TokenExpiredException : Exception
    {
        private static readonly int _code = 550;
        public static string _message = "Token Expired";

        public TokenExpiredException() : base($"{_code.ToString()}: {_message}") { } 
    }
}
