namespace MathSequence.App
{
    using System;
    using System.Linq;
    using System.Reflection;
    using MathSequence.App.Registrations;
    using MathSequence.Logic.Interfaces;
    using log4net;
    using StructureMap;

    public class Program
    {
        private static IContainer _container;
        private static ICalculationService _calculationService;
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            InitializeContainer();

            _calculationService = _container.GetInstance<ICalculationService>();

            _calculationService.Calculate().ToList().ForEach(i =>
            {
                log.Info($"Sequence No: {i}");
                Console.WriteLine(i);
            });

            Console.ReadLine();
        }

        private static void InitializeContainer()
        {
            _container = new Container(c =>
            {
                c.AddRegistry(new Registration());
            });
        }
    }
}
