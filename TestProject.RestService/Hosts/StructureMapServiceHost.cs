using System;
using System.ServiceModel.Web;
using MathSequence.RestService.Behaviours;

namespace MathSequence.RestService.Hosts
{
    public class StructureMapServiceHost : WebServiceHost
    {
        public StructureMapServiceHost()
        {
        }

        public StructureMapServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {
        }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new StructureMapServiceBehavior());
            base.OnOpening();
        }
    }
}
