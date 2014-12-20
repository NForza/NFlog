using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using NFlog.WebApi;

namespace NFlog.WebViewer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<NFlogWebApi>().As<INFlogWebApi>().SingleInstance();
            containerBuilder.RegisterType<WebApiDependencyResolver>().As<System.Web.Http.Dependencies.IDependencyResolver>();
            containerBuilder.Register<ILifetimeScope>(c => Container);
            //containerBuilder.Register<Action<NFlogMessage>>(c => c.Resolve<IShell>().MessageReceived);
            containerBuilder.RegisterApiControllers(typeof(MessageController).Assembly).InstancePerRequest();

            Container = containerBuilder.Build();

        }

        public IContainer Container { get; set; }
    }
}
         