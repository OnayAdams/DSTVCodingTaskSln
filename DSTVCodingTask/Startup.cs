using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSTVCodingTask.Startup))]
namespace DSTVCodingTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
