using System;
using System.ServiceModel;
using MathSequence.RestService.Hosts;
using MathSequence.RestService.Registrations;

namespace MathSequence.RestService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitializeContainer();

            string baseAddress = "http://localhost:9000/calculator";

            using (ServiceHost serviceHost = new StructureMapServiceHost(typeof(Calculator), new Uri(baseAddress)))
            {
                serviceHost.Open();

                Console.WriteLine("Service up and running at:");
                foreach (var endpoint in serviceHost.Description.Endpoints)
                {
                    Console.WriteLine(endpoint.Address);
                }
                Console.WriteLine("Press any key to close.");

                Console.ReadLine();

                serviceHost.Close();
            }
        }

        private static void InitializeContainer()
        {
            Singleton.Container.Configure(x =>
            {
                x.AddRegistry<Registration>();
            });
        }
    }
}
