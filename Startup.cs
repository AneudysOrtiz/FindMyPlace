using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindMyPlace.Startup))]
namespace FindMyPlace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
