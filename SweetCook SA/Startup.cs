using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SweetCook_SA.Startup))]
namespace SweetCook_SA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
