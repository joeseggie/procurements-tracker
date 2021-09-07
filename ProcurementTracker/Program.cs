using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProcurementTracker.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoadEnvironmentVariables();

            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetService<ProcurementTrackerContext>();
                ApplicationConfigurationManager.InitializeDatabase(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while initializing the database.");
            }
                
            host.Run();
        }

        private static void LoadEnvironmentVariables()
        {
            var appDirectory = Directory.GetCurrentDirectory();
            var dotenvPath = Path.Combine(appDirectory, ".env");
            ApplicationConfigurationManager.LoadEnvironmentVariables(dotenvPath);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
