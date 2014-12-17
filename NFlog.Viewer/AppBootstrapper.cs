using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Integration.WebApi;
using Caliburn.Micro;
using NFlog.Core;
using NFlog.WebApi;

namespace NFlog.Viewer
{
    public class AppBootstrapper : BootstrapperBase
    {
        public static IContainer Container = null;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
            containerBuilder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            containerBuilder.RegisterType<NFlogWebApi>().As<INFlogWebApi>().SingleInstance();
            containerBuilder.RegisterType<ShellViewModel>().As<IShell>().SingleInstance();
            containerBuilder.RegisterType<WebApiDependencyResolver>().As<IDependencyResolver>();
            containerBuilder.Register<ILifetimeScope>(c => Container);
            containerBuilder.Register<Action<NFlogMessage>>(c => c.Resolve<IShell>().MessageReceived);
            containerBuilder.RegisterApiControllers(typeof(MessageController).Assembly).InstancePerRequest();

            Container = containerBuilder.Build();

        }

        protected override object GetInstance(Type service, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (Container.IsRegistered(service))
                    return Container.Resolve(service);
            }
            else
            {
                if (Container.IsRegisteredWithKey(key, service))
                    return Container.ResolveKeyed(key, service);
            }
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", key ?? service.Name));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return Container.Resolve(typeof(IEnumerable<>).MakeGenericType(serviceType)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            Container.InjectProperties(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {            
            DisplayRootViewFor<IShell>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
            (Container.Resolve<INFlogWebApi>() as IDisposable).Dispose();
        }
    }
}