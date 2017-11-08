using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Autofac;
using AccessToHomes.Modules;
using System.Web.Http;
using System.Web.Routing;
using AccessToHomes.Code.Autofac;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace AccessToHomes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Run();

            GlobalConfiguration.Configure(WebApiConfig.Register);

    //        GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
    //new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            //Autofac Configuration
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
