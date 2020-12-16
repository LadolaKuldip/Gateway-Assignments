using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Source_Control_Final_Assignment.Startup))]
namespace Source_Control_Final_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
