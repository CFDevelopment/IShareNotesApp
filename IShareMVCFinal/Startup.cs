using IShareMVCFinal.API_Data;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IShareMVCFinal.Startup))]
namespace IShareMVCFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            /*NewsAPI.RunAsync();*/
        }
    }
}
