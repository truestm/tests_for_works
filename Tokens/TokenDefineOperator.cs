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

        public TokenDefineOperator(TokenType tokenType, char symbol) : this(tokenType, -1, symbol) { }

        public override bool Start(char c) { return c == Symbol; }
        public override bool Match(char c) { return false; }

        public override void Calculate(Token token, Stack<object> stack)
        {
            throw new Exception($"Not calculable token '{this}'.");
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
