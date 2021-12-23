using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Tokenizer
    {
        public enum LexemeType
        {
            Const,
            Add,
            Sub,
            Mul,
            Div
        }

        public class Lexeme
        {
            public LexemeType LexemeType { get; private set; }
            public object Value { get; private set; }

            public Lexeme(LexemeType type, object value = null)
            {
                LexemeType = type;
                Value = value;
            }
        }

        static readonly Dictionary<char, LexemeType> operators = new Dictionary<char, LexemeType>()
        {
            { '+', LexemeType.Add },
            { '-', LexemeType.Sub },
            { '*', LexemeType.Mul },
            { '/', LexemeType.Div },
        };

        string text;

        public Tokenizer(string text)
        {
            this.text = text;
        }

        static string toStringUntil(IEnumerator<char?> e, Func<char?,bool> predicate )
        {
            var s = new StringBuilder();
            do
            {
                if (!predicate(e.Current))
                    break;
                s.Append(e.Current);
            }
            while (e.MoveNext());
            return s.ToString();
        }

        public IEnumerable<Lexeme> lexemes()
        {
            using (var e = new StringEnumerable.Enumerator(text, 0, text.Length))
            {
                if (e.MoveNext())
                {
                    
                    do
                    {
                        if (e.Current != null && !char.IsWhiteSpace(e.Current.Value))
                        {
                            if (char.IsDigit(e.Current.Value))
                            {
                                var value = Double.Parse(toStringUntil(e, c => c != null && (char.IsDigit(e.Current.Value) || c == '.')));
                                yield return new Lexeme(LexemeType.Const, value);
                                continue;
                            }
                            if(operators.TryGetValue(e.Current.Value, out var lexemeType))
                            {
                                yield return new Lexeme(lexemeType);
                            }
                        }
                    }
                    while (e.MoveNext());
                }
            }
        }
    }
}
