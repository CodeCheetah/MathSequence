using StructureMap.Configuration.DSL;
using MathSequence.Logic.Interfaces;
using MathSequence.Logic.Services;

namespace MathSequence.RestService.Registrations
{
    public class Registration : Registry
    {
        public Registration()
        {
            For<ICalculationService>().Use<CalculationService>();
        }
    }
}
