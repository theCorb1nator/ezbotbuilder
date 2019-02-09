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

namespace msteams.commandbot
{
    public class Program
    {
        static void Main(string[] args)
                  => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string [] args)
        {

       
            var host = CreateWebHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    await services.GetRequiredService<CommandHandlingService>().InitializeAsync();
                    // Use the context here
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
        {
            // Add Azure Logging
            logging.AddAzureWebAppDiagnostics();
        })
        .UseStartup<Startup>();
    }
}
