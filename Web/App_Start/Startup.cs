using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(InstaRetail.Web.Startup))]
namespace InstaRetail.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseWebApi();
        }
    }
}