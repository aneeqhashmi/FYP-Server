using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CitizenPulse.Startup))]
namespace CitizenPulse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
