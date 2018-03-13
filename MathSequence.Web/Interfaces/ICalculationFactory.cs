using System.Collections.Generic;

namespace MathSequence.Web.Interfaces
{
    public interface ICalculationFactory
    {
        IEnumerable<int> Calculate();
        int Sum(int limit);
    }
}