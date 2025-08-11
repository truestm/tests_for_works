using System;

namespace Calc.Tokens
{
    public class TokenException : Exception
    {
        public TokenException(string message):base(message)
        {
        }
    };
}
