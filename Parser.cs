using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Parser
    {
        public abstract class Token
        {
            public abstract object Result();
        }

        public abstract class TokenBinaryOperation : Token
        {
            Token left;
            Token right;
        }

        public abstract class TokenUnaryOperation : Token
        {
            Token token;
        }

        Token build(string text)
        {
            var tokenizer = new Tokenizer(text);
            foreach( var lexeme in tokenizer.lexemes() )
            {

            }
            return null;
        }
    }
}
