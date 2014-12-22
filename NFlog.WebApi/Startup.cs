using System.Web.Http;
using System.Web.Http.Dependencies;
using Owin;

namespace NFlog.WebApi
{
    public class Startup
    {
        private readonly IDependencyResolver dependencyResolver;

        public Startup(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        // This code configures Web API contained in the class Startup, which is additionally specified as the type parameter in WebApplication.Start
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = dependencyResolver;
            config.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(config);
        }
    }
}
