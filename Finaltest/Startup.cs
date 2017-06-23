using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Finaltest.Startup))]
namespace Finaltest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
