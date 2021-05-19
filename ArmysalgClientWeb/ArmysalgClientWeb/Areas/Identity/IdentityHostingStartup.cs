using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ArmysalgClientWeb.Areas.Identity.IdentityHostingStartup))]
namespace ArmysalgClientWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}