using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Evaluator : IEvaluator
    {
        public async Task<object> EvalAsync(string expression)
        {
            return expression;
        }
    }
}
