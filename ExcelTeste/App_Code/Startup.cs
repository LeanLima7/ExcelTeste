using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExcelTeste.Startup))]
namespace ExcelTeste
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
