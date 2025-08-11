using System.Threading.Tasks;

namespace Calc
{
    public interface IEvaluator
    {
        Task<object> EvalAsync(string expression);
    }
}
