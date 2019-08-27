using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.Data;
using NewsPortal.Domain;
using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal
{
    public static class WebHostExtension
    {
        public static IWebHost Migrate(this IWebHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.Migrate();
            }

            return webHost;
        }

        public static async Task<IWebHost> SeedingData(this IWebHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var rolesManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                var hostingEnvironment = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();

                if (!context.Newss.Any())
                {
                    await DataSeeder.InitNews(context);
                }

                await DataSeeder.InitUsers(userManager, rolesManager);
            }

            return webHost;
        }
    }
}
