using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class StringEnumerator : IEnumerator<char?>
    {
        readonly int start;
        readonly int end;

        public string Text { get; private set; }
        public int Pos { get; private set; }

        public StringEnumerator(string text, int start, int end)
        {
            this.Text = text;
            this.start = start;
            this.end = end;
            Reset();
        }

        public char? Current
        {
            get
            {
                if (Text != null && Pos >= start && Pos < Text.Length)
                    return Text[Pos];
                return null;
            }
        }


        object IEnumerator.Current => Current;

        public void Dispose(){}

        public bool MoveNext()
        {
            if (Text == null || Pos >= end)
                return false;
            return ++Pos < end;
        }

        public void Reset()
        {
            Pos = start - 1;
        }

        public static string Substring(IEnumerator<char?> symbol, Func<char, bool> predicate)
        {
            var str = new StringBuilder().Append(symbol.Current);
            while (symbol.MoveNext() && predicate(symbol.Current.Value))
            {
                str.Append(symbol.Current);
            }
            return str.ToString();
        }

        public string Substring(Func<char, bool> predicate)
        {
            return Substring(this, predicate);
        }
    }
}
