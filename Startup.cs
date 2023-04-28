using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogPl.Startup))]
namespace BlogPl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
