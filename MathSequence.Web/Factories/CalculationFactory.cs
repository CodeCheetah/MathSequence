using System.Collections.Generic;
using System.Linq;
using MathSequence.Logic.Interfaces;
using MathSequence.Web.Interfaces;

namespace MathSequence.Web.Factories
{
    public class CalculationFactory : ICalculationFactory
    {
        protected readonly ICalculationService _calculationService;
        protected readonly ILogWrapper _logger;

        public CalculationFactory(ICalculationService calculationService, ILogWrapper logger)
        {
            _calculationService = calculationService;
            _logger = logger;
        }

        public IEnumerable<int> Calculate()
        {
            var result = _calculationService.Calculate();

            result.ToList().ForEach(x =>
            {
                _logger.Info(x.ToString());
            });

            return result;
        }

        public int Sum(int limit)
        {
            var result = _calculationService.Sum(limit);
            return result;
        }
    }
}