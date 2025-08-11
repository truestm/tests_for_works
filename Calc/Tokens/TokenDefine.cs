using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calc.Tokens
{
    public enum TokenType
    {
        None,
        Const,
        Function,
        Open,
        Close,
        Delim,
        Binary,
        Unary
    };

    public abstract class TokenDefine
    {
        public readonly int Precedence;
        public readonly TokenType TokenType;

        public TokenDefine(TokenType tokenType, int precedence)
        {
            TokenType = tokenType;
            Precedence = precedence;
        }

        public abstract bool Start(char c);
        public abstract bool Match(char c);
        public abstract void Calculate(Token token, Stack<object> stack);

        public virtual Token Create(string value)
        {
            return new Token(this);
        }
    };

    public abstract class TokenDefine<TValue> : TokenDefine
    {
        public TokenDefine(TokenType tokenType, int precedence):base(tokenType, precedence)
        {
        }
        
        public sealed override void Calculate(Token token, Stack<object> stack)
        {
            Calculate((Token<TValue>)token, stack);
        }

        public abstract void Calculate(Token<TValue> token, Stack<object> stack);

        public override Token Create(string value)
        {
            return new Token<TValue>(this, (TValue)Convert.ChangeType(value, typeof(TValue), CultureInfo.InvariantCulture));
        }
    };
}