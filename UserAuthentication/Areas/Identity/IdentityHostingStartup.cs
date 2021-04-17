using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserAuthentication.Areas.Identity.Data;
using UserAuthentication.Data;

[assembly: HostingStartup(typeof(UserAuthentication.Areas.Identity.IdentityHostingStartup))]
namespace UserAuthentication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserAuthenticationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserAuthenticationDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UserAuthenticationDbContext>();
            });
        }
    }
}