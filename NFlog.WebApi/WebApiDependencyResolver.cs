using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Integration.WebApi;

namespace NFlog.WebApi
{
    public class WebApiDependencyResolver: IDependencyResolver
    {
        private AutofacWebApiDependencyResolver resolver;
        public WebApiDependencyResolver(ILifetimeScope container)
        {
            resolver = new AutofacWebApiDependencyResolver(container);
        }

        public IDependencyScope BeginScope()
        {
            return resolver.BeginScope();
        }

        public object GetService(System.Type serviceType)
        {
            return resolver.GetService(serviceType);
        }

        public System.Collections.Generic.IEnumerable<object> GetServices(System.Type serviceType)
        {
            return resolver.GetServices(serviceType);
        }

        public void Dispose()
        {
            resolver.Dispose();        
        }
    }
}
