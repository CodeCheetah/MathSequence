namespace MathSequence.App.Registrations
{
    using StructureMap.Configuration.DSL;
    using MathSequence.Logic.Interfaces;
    using MathSequence.Logic.Services;

    public class Registration : Registry
    {
        public Registration()
        {
            For<ICalculationService>().Use<CalculationService>();
        }
    }
}
