using System;
using System.Collections.Generic;

namespace Calc.Tokens
{
    public class TokenDefineOperator : TokenDefine
    {
        char Symbol;

        public TokenDefineOperator(TokenType tokenType, int precedence, char symbol) : base(tokenType, precedence)
        {
            Symbol = symbol;
        }

        public override bool Start(char c) { return c == Symbol; }
        public override bool Match(char c) { return false; }

        public override void Calculate(Token token, Stack<object> stack)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
