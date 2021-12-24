using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public enum TokenType
    {
        None,
        Const,
        Open,
        Close,
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

    public class TokenDefineNumber : TokenDefine
    {
        public TokenDefineNumber(int precedence) : base(TokenType.Const, precedence){}

        public override void Calculate(Token token, Stack<object> stack)
        {
            stack.Push(token.Value);
        }

        public override bool Start(char c) { return char.IsDigit(c); }
        public override bool Match(char c) { return char.IsDigit(c) || c == '.'; }

        public override Token Create(string value)
        {
            return new Token(this, double.Parse(value, CultureInfo.InvariantCulture));
        }
    }

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
    
    public class TokenDefineOperatorBinary : TokenDefineOperator
    {
        Func<object, object, object> Operation;

        public TokenDefineOperatorBinary(int precedence, char symbol, Func<object, object, object> operation): 
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

    public class Token
    {
        public TokenDefine Define { get; private set; }
        public object Value;
        
        public Token(TokenDefine define, object value = null )
        {
            Define = define;
            Value = value;
        }

        public void Calculate(Stack<object> stack)
        {
            Define.Calculate(this, stack);
        }

        public override string ToString()
        {
            return Value?.ToString() ?? Define.ToString();
        }
    }
}