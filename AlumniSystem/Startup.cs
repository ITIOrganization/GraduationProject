using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlumniSystem.Startup))]
namespace AlumniSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
