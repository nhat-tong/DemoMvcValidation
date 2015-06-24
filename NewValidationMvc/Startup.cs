using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewValidationMvc.Startup))]
namespace NewValidationMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
