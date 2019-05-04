using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shopwalletapp.Startup))]
namespace shopwalletapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
