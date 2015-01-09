using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using NFlog.Core;
using NFlog.WebApi;
using NFlog.WebViewer.Controllers;

namespace NFlog.WebViewer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);
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
            containerBuilder.RegisterType<AzureTableStorageReceiver>().As<IMessageReceiver>().InstancePerRequest();
            containerBuilder.RegisterType<AzureTableStorageProvider>().As<IMessageProvider>().InstancePerRequest();
            containerBuilder.RegisterApiControllers(typeof(MessageController).Assembly).InstancePerRequest();
            containerBuilder.RegisterControllers(typeof (HomeController).Assembly);
            Container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        public static IContainer Container { get; set; }
    }
}
         