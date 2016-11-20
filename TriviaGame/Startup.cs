using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TriviaGame.Startup))]
namespace TriviaGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
