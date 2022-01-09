using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eat4Fit.Startup))]
namespace Eat4Fit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
