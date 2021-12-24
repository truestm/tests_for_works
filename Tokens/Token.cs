using System.Collections.Generic;

namespace Calc.Tokens
{
    public class Token
    {
        public TokenDefine Define { get; private set; }

        public Token(TokenDefine define)
        {
            Define = define;
        }

        public void Calculate(Stack<object> stack)
        {
            Define.Calculate(this, stack);
        }

        public override string ToString()
        {
            return Define.ToString();
        }
    }

    public class Token<TValue> : Token
    {
        public TValue Value;

        public Token(TokenDefine define, TValue value):base(define)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? base.ToString();
        }
    }
}
