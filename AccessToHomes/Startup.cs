using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccessToHomes.Startup))]
namespace AccessToHomes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
