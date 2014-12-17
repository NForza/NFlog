using System;
using System.Web.Http.Dependencies;
using Microsoft.Owin.Hosting;

namespace NFlog.WebApi
{
    public class NFlogWebApi : INFlogWebApi, IDisposable
    {
        private IDisposable app;

        public NFlogWebApi( Func<IDependencyResolver> dependencyResolver )
        {
            Startup s = new Startup(dependencyResolver());

            app = WebApp.Start("http://localhost:12349", s.Configuration);
        }

        ~NFlogWebApi()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (app != null)
            {
                app.Dispose();
                app = null;
                GC.SuppressFinalize(this);
            }
        }
    }
}