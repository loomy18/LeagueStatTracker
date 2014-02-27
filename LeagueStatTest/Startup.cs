using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeagueStatTest.Startup))]
namespace LeagueStatTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
