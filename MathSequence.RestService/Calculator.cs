using System.Collections.Generic;
using MathSequence.Logic.Interfaces;
using MathSequence.RestService.Interfaces;

namespace MathSequence.RestService
{
    public class Calculator : ICalculator
    {
        protected ICalculationService _calculationService;

        public Calculator(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public IEnumerable<int> Calculate()
        {
            return _calculationService.Calculate();
        }

        public int Sum(string limit)
        {
            int.TryParse(limit, out int max);
            return _calculationService.Sum(max);
        }
    }
}
