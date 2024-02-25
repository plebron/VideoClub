using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoClub.Startup))]
namespace VideoClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
