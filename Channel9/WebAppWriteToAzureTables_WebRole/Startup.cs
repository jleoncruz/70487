using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppWriteToAzureTables_WebRole.Startup))]
namespace WebAppWriteToAzureTables_WebRole
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
