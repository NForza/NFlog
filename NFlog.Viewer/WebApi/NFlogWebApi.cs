using System;
using Microsoft.Owin.Hosting;

namespace NFlog.Viewer.WebApi
{
    internal class NFlogWebApi : INFlogWebApi, IDisposable
    {
        private IDisposable app;

        public NFlogWebApi()
        {
            app = WebApp.Start<Startup>("http://localhost:12349");
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