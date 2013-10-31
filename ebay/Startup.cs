using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ebay.Startup))]
namespace ebay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
