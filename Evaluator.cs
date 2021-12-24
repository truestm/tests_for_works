using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Evaluator : IEvaluator
    {
        public Task<object> EvalAsync(string expression)
        {
            return Task.Run(() => Eval(expression));
        }

        object Eval(string expression)
        {
            var tokenizer = new Tokenizer(expression);
            var tokens = tokenizer.RPNTokens().ToArray();

            var stack = new Stack<object>();
            foreach (var token in tokens)
                token.Calculate(stack);

            return $"{string.Join(" ", tokens.Select(x => x.ToString()))} = {stack.Pop()}";
        }
    }
}
