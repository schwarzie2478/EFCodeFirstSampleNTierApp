
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace TestServiceActivation
{
    public class Start
    {
        public static Castle.Windsor.WindsorContainer container = new Castle.Windsor.WindsorContainer();
        public static void AppInitialize()
        {
            //container.Kernel.AddFacility<WcfFacility>();
            //container.Kernel.Register(Component.For<IEntityReadService<MyEntity>>()
            //                                   .ImplementedBy<GenericService<MyEntity>>()
            //                                   .Named("EntityService"));
        }
    }
}
