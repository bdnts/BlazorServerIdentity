using System;
using BlazorServerIdentity.Areas.Identity.Data;
using BlazorServerIdentity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BlazorServerIdentity.Areas.Identity.IdentityHostingStartup))]
namespace BlazorServerIdentity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BlazorServerIdentityContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("BlazorServerIdentityContextConnection")));

                services.AddDefaultIdentity<BlazorServerIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BlazorServerIdentityContext>();
            });
        }
    }
}