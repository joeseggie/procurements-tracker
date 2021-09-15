using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProcurementTracker.Data;
using ProcurementTracker.Models;

[assembly: HostingStartup(typeof(ProcurementTracker.Areas.Identity.IdentityHostingStartup))]
namespace ProcurementTracker.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<ApplicationUser>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                        options.SignIn.RequireConfirmedEmail = false;
                        options.SignIn.RequireConfirmedPhoneNumber = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                    }
                )
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ProcurementTrackerContext>();
            });
        }
    }
}