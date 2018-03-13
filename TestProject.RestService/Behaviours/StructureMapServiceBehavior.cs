using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Collections.ObjectModel;
using MathSequence.RestService.Providers;

namespace MathSequence.RestService.Behaviours
{
    public class StructureMapServiceBehavior : IServiceBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;
                if (cd != null)
                {
                    foreach (EndpointDispatcher ed in cd.Endpoints)
                    {
                        ed.DispatchRuntime.InstanceProvider = new StructureMapInstanceProvider(serviceDescription.ServiceType);
                    }
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
