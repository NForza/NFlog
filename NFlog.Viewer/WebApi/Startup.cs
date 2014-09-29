using System.Web.Http;
using Autofac.Integration.WebApi;
using Owin;

namespace NFlog.Viewer.WebApi
{
    public class Startup
    {
        // This code configures Web API contained in the class Startup, which is additionally specified as the type parameter in WebApplication.Start
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(AppBootstrapper.Container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
