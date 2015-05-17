using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarryMe.Startup))]
namespace MarryMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
