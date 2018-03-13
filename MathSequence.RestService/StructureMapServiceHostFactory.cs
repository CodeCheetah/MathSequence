using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using StructureMap;
using StructureMap.Configuration;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using TestProject.RestService.Registrations;

namespace TestProject.RestService
{
    public class StructureMapServiceHostFactory : ServiceHostFactory
    {
        private IContainer _container;

        public StructureMapServiceHostFactory()
        {
            _container = new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.TheCallingAssembly();
                    scan.LookForRegistries();
                    scan.WithDefaultConventions();
                });
                x.AddRegistry(new Registration());
            });
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new StructureMapServiceHost(serviceType, baseAddresses);
        }
    }
}
