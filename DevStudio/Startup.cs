using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevStudio.Startup))]
namespace DevStudio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
