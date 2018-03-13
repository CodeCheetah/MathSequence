namespace MathSequence.Tests
{
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using StructureMap;
    using FluentAssertions;
    using MathSequence.Logic.Interfaces;

    [TestFixture]
    public class UnitTestMock
    {
        private IContainer _container;
        private Mock<ICalculationService> _calculationService;

        [OneTimeSetUp]
        public void SetUp()
        {
            var mockCalculationService = Mock.Of<ICalculationService>();
            _calculationService = Mock.Get(mockCalculationService);
        }

        [Test]
        public void Check_Mock_Sequence_ThirdNumber()
        {
            var numbers = new int[] { 2, 5, 7 };
            _calculationService.Setup(x => x.Calculate()).Returns(numbers);

            var results = _calculationService.Object.Calculate().ToArray();
            results[2].Should().Be(7);
        }
    }
}
