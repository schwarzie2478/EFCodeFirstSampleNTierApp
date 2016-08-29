using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TestServiceActivation
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Start.container.Kernel.AddFacility<WcfFacility>();
            Start.container.Kernel.Register(Component.For<IBusinessController<MyEntity>>()
                .ImplementedBy<MyEntityBusinessController>());

            Start.container.Kernel.Register(Component.For<IEntityEditService<YourEntity>>()
                .ImplementedBy<GenericService<YourEntity, IBusinessController<YourEntity>>>()
                .Named("YourEntityService"));
            Start.container.Kernel.Register(Component.For<IEntityEditService<MyEntity>>()
                .ImplementedBy<GenericService<MyEntity, IBusinessController<MyEntity>>>()
                .Named("MyEntityService"));

        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}