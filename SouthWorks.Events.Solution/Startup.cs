using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SouthWorks.Events.Solution.Startup))]
namespace SouthWorks.Events.Solution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
