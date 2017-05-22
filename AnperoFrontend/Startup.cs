using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnperoFrontend.Startup))]
namespace AnperoFrontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
