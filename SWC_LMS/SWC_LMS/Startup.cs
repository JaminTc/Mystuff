using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SWC_LMS.Startup))]
namespace SWC_LMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
