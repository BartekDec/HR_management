using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HR_management.Startup))]
namespace HR_management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
