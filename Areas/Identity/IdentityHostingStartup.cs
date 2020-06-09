using System;
using BakeryApp.Areas.Identity.Data;
using BakeryApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BakeryApp.Areas.Identity.IdentityHostingStartup))]
namespace BakeryApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BakeryAppUsersContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BakeryAppUsersContextConnection")));

                services.AddDefaultIdentity<BakeryAppAdmin>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BakeryAppUsersContext>();
            });
        }
    }
}