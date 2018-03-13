namespace MathSequence.Tests
{
    using System.Linq;
    using NUnit.Framework;
    using StructureMap;
    using FluentAssertions;
    using MathSequence.Logic.Interfaces;
    using MathSequence.Logic.Services;

    [TestFixture]
    public class UnitTest
    {
        private IContainer _container;
        private ICalculationService _calculationService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _container = new Container(x =>
            {
                x.For<ICalculationService>().Use<CalculationService>();
            });
            _container.AssertConfigurationIsValid();

            _calculationService = _container.GetInstance<ICalculationService>();
        }

        [Test]
        public void Check_Sequence_ThirdNumber()
        {
            var results = _calculationService.Calculate().ToArray();
            results[2].Should().Be(5);
        }


        [Test]
        public void Sum_Sequence()
        {
            var result = _calculationService.Sum(8);
            result.Should().NotBe(0);
            result.Should().Be(10);
        }
    }
}
