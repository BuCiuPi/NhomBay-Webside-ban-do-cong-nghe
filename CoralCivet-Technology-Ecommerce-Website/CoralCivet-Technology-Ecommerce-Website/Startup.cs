using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoralCivet_Technology_Ecommerce_Website.Startup))]
namespace CoralCivet_Technology_Ecommerce_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
