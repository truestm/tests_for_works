using System.Collections;
using System.Collections.Generic;

namespace Calc
{
    public class StringEnumerable : IEnumerable<char>
    {
        string text;
        int start;
        int end;

        public class Enumerator : IEnumerator<char>
        {
            string text;
            int start;
            int end;
            int pos;

            public Enumerator(string text, int start, int end)
            {
                this.text = text;
                this.start = start;
                this.end = end;
            }

            public char Current => text[start];

            object IEnumerator.Current => Current;

            public void Dispose(){}

            public bool MoveNext()
            {
                if (text == null || pos + 1 < end)
                    return false;
                ++pos;
                return true;
            }

            public void Reset()
            {
                pos = start;
            }
        };

        public StringEnumerable(string text, int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public StringEnumerable(string text, int start):this(text,start, text.Length){}
        public StringEnumerable(string text) : this(text, 0, text.Length) { }

        public IEnumerator<char> GetEnumerator()
        {
            return new Enumerator(text, start, end);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
