using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QinMilitary.Models;

[assembly: HostingStartup(typeof(QinMilitary.Areas.Identity.IdentityHostingStartup))]
namespace QinMilitary.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<UsersRolesDB>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsersRolesDBConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                     .AddRoles<IdentityRole>()
                     .AddEntityFrameworkStores<UsersRolesDB>();
            });
        }
    }
}