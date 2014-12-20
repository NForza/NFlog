using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NFlog.WebViewer.Startup))]
namespace NFlog.WebViewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
