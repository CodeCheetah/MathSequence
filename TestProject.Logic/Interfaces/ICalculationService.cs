namespace MathSequence.Logic.Interfaces
{
    using System.Collections.Generic;

    public interface ICalculationService
    {
        IEnumerable<int> Calculate();
        int Sum(int limit);
    }
}
