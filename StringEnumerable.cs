using System;
using System.Collections;
using System.Collections.Generic;

namespace Calc
{
    public class StringEnumerable : IEnumerable<char?>
    {
        string text;
        int start;
        int end;

        public class Enumerator : IEnumerator<char?>
        {
            int start;
            int end;

            public string Text { get; private set; }
            public int Pos { get; private set; }

            public Enumerator(string text, int start, int end)
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
        }
        public StringEnumerable(string text, int start, int end)
        {
            this.text = text;
            this.start = start;
            this.end = end;
        }

        public StringEnumerable(string text, int start):this(text,start, text.Length){}
        public StringEnumerable(string text) : this(text, 0, text.Length) { }

        public IEnumerator<char?> GetEnumerator()
        {
            return new Enumerator(text, start, end);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
