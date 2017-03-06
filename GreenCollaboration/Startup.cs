using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenCollaboration.Startup))]
namespace GreenCollaboration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
