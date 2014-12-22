using System.Web.Http;
using NFlog.WebApi;

namespace NFlog.WebViewer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            
            config.DependencyResolver = new WebApiDependencyResolver(MvcApplication.Container);
            // Web API routes
            config.MapHttpAttributeRoutes();            
        }
    }
}
