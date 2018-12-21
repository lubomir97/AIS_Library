using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIS_Library.Startup))]
namespace AIS_Library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
