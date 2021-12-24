using System;
using System.Collections.Generic;

namespace Calc.Tokens
{
    public class TokenDefineOperatorBinary : TokenDefineOperator
    {
        Func<object, object, object> Operation;

        public TokenDefineOperatorBinary(int precedence, char symbol, Func<object, object, object> operation) :
            base(TokenType.Binary, precedence, symbol)
        {
            Operation = operation;
        }

        public override void Calculate(Token token, Stack<object> stack)
        {
            var right = stack.Pop();
            var left = stack.Pop();
            var result = Operation(left, right);
            stack.Push(result);
        }
    }
}
