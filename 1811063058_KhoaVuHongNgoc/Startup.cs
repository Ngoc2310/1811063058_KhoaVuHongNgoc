using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1811063058_KhoaVuHongNgoc.Startup))]
namespace _1811063058_KhoaVuHongNgoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
