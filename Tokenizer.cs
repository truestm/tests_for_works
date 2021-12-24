using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Tokenizer
    {
        private static readonly TokenDefine[] defines = new TokenDefine[]
        {
            new TokenDefineOperator(TokenType.Open,  -1, '('),
            new TokenDefineOperator(TokenType.Close, -1, ')'),
            new TokenDefineNumber(-1),
            new TokenDefineOperatorBinary(6, '+', (l,r) => (double)l + (double)r),
            new TokenDefineOperatorBinary(6, '-', (l,r) => (double)l - (double)r),
            new TokenDefineOperatorBinary(8, '*', (l,r) => (double)l * (double)r),
            new TokenDefineOperatorBinary(8, '/', (l,r) => (double)l / (double)r),
        };
        
        readonly string text;

        public Tokenizer(string text)
        {
            this.text = text;
        }

        static string toStringUntil(IEnumerator<char?> e, Func<char, bool> predicate)
        {
            var s = new StringBuilder().Append(e.Current);
            while (e.MoveNext() && !predicate(e.Current.Value))
            {
                s.Append(e.Current);
            }
            return s.ToString();
        }

        public IEnumerable<Token> Tokens()
        {
            using (var symbol = new StringEnumerable.Enumerator(text, 0, text.Length))
            {
                if (symbol.MoveNext())
                {
                    while (true)
                    {
                        if (symbol.Current != null && !char.IsWhiteSpace(symbol.Current.Value))
                        {
                            var define = defines.FirstOrDefault(x => x.Start(symbol.Current.Value));
                            if (define == null)
                                throw new Exception($"Token '{symbol.Current}' not defined.");
                            yield return define.Create(toStringUntil(symbol, define.End));
                        }
                        else
                        {
                            if (!symbol.MoveNext())
                                break;
                        }
                    }
                }
            }
        }

        public IEnumerable<Token> RPNTokens()
        {
            var stack = new Stack<Token>();
            foreach (var token in Tokens())
            {
                switch(token.Define.TokenType)
                {
                    case TokenType.Const:
                        yield return token;
                        break;
                    case TokenType.Open:
                        stack.Push(token);
                        break;
                    case TokenType.Close:
                        while (stack.Count > 0 && stack.Peek().Define.TokenType != TokenType.Open)
                        {
                            yield return stack.Pop();
                        }
                        if (stack.Count == 0)
                            throw new Exception("Unexpected )");
                        stack.Pop();
                        break;
                    default:
                        while (stack.Count > 0 &&
                            stack.Peek().Define.TokenType != TokenType.Open &&
                            stack.Peek().Define.Precedence >= token.Define.Precedence)
                        {
                            yield return stack.Pop();
                        }
                        stack.Push(token);
                        break;
                }
            }
            while (stack.Count != 0)
            {
                if(stack.Peek().Define.TokenType == TokenType.Open)
                    throw new Exception("Unexpected (");
                yield return stack.Pop();
            }
        }
    }
}
