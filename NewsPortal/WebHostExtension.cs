using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.Data;
using NewsPortal.Domain;
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

        public static IWebHost SeedingData(this IWebHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                var hostingEnvironment = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();

                if (hostingEnvironment.EnvironmentName == "Debug" && !context.Newss.Any())
                {
                    DataSeeder.InitData(context);
                }
            }

            return webHost;
        }
    }
}
