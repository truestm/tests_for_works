using System;
using System.Collections.Generic;

namespace Calc.Tokens
{
    public class TokenDefineOperatorUnary : TokenDefineOperator
    {
        Func<object, object> Operation;

        public TokenDefineOperatorUnary(int precedence, char symbol, Func<object, object> operation) :
            base(TokenType.Unary, precedence, symbol)
        {
            Operation = operation;
        }

        public override void Calculate(Token token, Stack<object> stack)
        {
            var right = stack.Pop();
            var result = Operation(right);
            stack.Push(result);
        }
    }
}
