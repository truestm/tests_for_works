using System;
using System.Collections.Generic;

namespace Calc.Tokens
{
    public class TokenDefineFunction : TokenDefine<string>
    {
        private static readonly Dictionary<string, (int, Func<object[], object>)> functions = new Dictionary<string, (int, Func<object[], object>)>
        {
            { "pi",   CreateFunction(() => Math.PI)},
            { "max",  CreateFunction((double x, double y) => Math.Max(x,y))},
            { "min",  CreateFunction((double x, double y) => Math.Min(x,y))},
            { "sin",  CreateFunction((double x) => Math.Sin(x))},
            { "cos",  CreateFunction((double x) => Math.Cos(x))},
            { "sqrt", CreateFunction((double x) => Math.Sqrt(x))},
            { "pow",  CreateFunction((double x, double y) => Math.Pow(x,y))},
        };

        public TokenDefineFunction(int precedence) : base(TokenType.Function, precedence) { }

        public override Token Create(string value)
        {
            if (!functions.ContainsKey(value))
                throw new TokenException($"Unknown function '{value}'");

            return base.Create(value);
        }

        public override void Calculate(Token<string> token, Stack<object> stack)
        {
            var (count, func) = functions[token.Value];
            var args = new object[count];
            for (var i = args.Length - 1; i >= 0; --i)
                args[i] = stack.Pop();
            var result = func(args);
            stack.Push(result);
        }

        public override bool Start(char c) { return char.IsLetter(c); }
        public override bool Match(char c) { return char.IsLetter(c); }

        private static (int, Func<object[], object>) CreateFunction       (Func<object> func)         { return (0, args => func()); }
        private static (int, Func<object[], object>) CreateFunction<T1>   (Func<T1,object> func)      { return (1, args => func((T1)args[0])); }
        private static (int, Func<object[], object>) CreateFunction<T1,T2>(Func<T1, T2, object> func) { return (2, args => func((T1)args[0], (T2)args[1])); }
    }
}
