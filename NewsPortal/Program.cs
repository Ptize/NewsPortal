using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static NewsPortal.Logging.LoggerExtensions.Main.ProgramLogger;

namespace NewsPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            try
            {
                logger.MigratingDatabase();
                host.Migrate();

                logger.DatabaseWasMigrated();
            } 
            catch(Exception ex)
            {
                logger.MigratingDatabaseFailed(ex);
                throw ex;
            }

            try
            {
                logger.SeedingDatabase();
                host.SeedingData().Wait();

                logger.DatabaseWasSeeded();
            }
            catch (Exception ex)
            {
                logger.SeedingDatabaseFailed(ex);
                throw ex;
            }


            logger.RunningWebHost();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                });
    }
}
