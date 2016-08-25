using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace TestServiceActivation
{
    public class MyServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = new ServiceHost(serviceType, baseAddresses);
            //host.AddServiceEndpoint(typeof(IEntityReadService<MyEntity>), new WSHttpBinding(),"");
            return host;
        }
    }
}