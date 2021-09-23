using Demo.Core;
using Demo.Infras;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Api
{
    public static class Program
    {
        internal static bool EnabledAzureAppConfiguration { get; private set; }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseAppInsightsLog(c =>
                {
#if DEBUG
                    c.AddConsole();
#endif
                })
                .ConfigureAppConfiguration((host, config) =>
                {
                    config.AddJsonFile("appsettings.json", true)
                        .AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json", true)
                        .AddEnvironmentVariables();

                    var appConfig = config.Build().GetConnectionString("AppConfig");
                    if (string.IsNullOrWhiteSpace(appConfig)) return;

                    //Load Feature Management from Azure App Configuration.
                    config.AddAzureAppConfiguration(options =>
                        options
                            .Select(KeyFilter.Any, SettingKeys.ApiName)
                            .Connect(appConfig)
                            .UseFeatureFlags());

                    EnabledAzureAppConfiguration = true;
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await host.RunAsync().ConfigureAwait(false);
        }
    }
}
