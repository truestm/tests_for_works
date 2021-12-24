using System.Collections.Generic;

namespace Calc.Tokens
{
    public class TokenDefineNumber : TokenDefine<double>
    {
        public TokenDefineNumber(int precedence) : base(TokenType.Const, precedence) { }

        public override void Calculate(Token<double> token, Stack<object> stack)
        {
            stack.Push(token.Value);
        }

        public override bool Start(char c) { return char.IsDigit(c); }
        public override bool Match(char c) { return char.IsDigit(c) || c == '.'; }
    }
}
