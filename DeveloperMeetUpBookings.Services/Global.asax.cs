using Autofac;
using Autofac.Integration.WebApi;
using DeveloperMeetUpBookings.Repository.Repositories;
using DeveloperMeetUpBookings.Queries.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DeveloperMeetUpBookings.Services
{
    public class Global : System.Web.HttpApplication
    {

        // RegisterRoutes and RegisterGlobalFilters removed ...

        /// <summary>
        /// Fired when the first resource is requested from the web server and the web application starts
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<IBookingService>().As<BookingService>().InstancePerRequest();

            builder.RegisterType<IBookingRepository>().As<BookingRepository>().InstancePerRequest();

            builder.RegisterType<IBookingCRUDRepository>().As<BookingCRUDRepository>().InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
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