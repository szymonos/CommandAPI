using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Azure.Identity;

namespace CommandAPI {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) => {
                        var settings = config.Build();
                        var appcfEndpoint = Environment.GetEnvironmentVariable("APPCF_ENDPOINT");
                        var credential = new DefaultAzureCredential();
                        config.AddAzureAppConfiguration(options => {
                            options.Connect(new Uri(appcfEndpoint), credential)
                                .Select("ConnectionStrings:CmdDbPgsql", hostingContext.HostingEnvironment.EnvironmentName)
                                .Select("Settings:DB:*", hostingContext.HostingEnvironment.EnvironmentName)
                                .ConfigureRefresh(refresh => {
                                    refresh.Register("Settings:Sentinel", refreshAll: true)
                                        .SetCacheExpiration(new TimeSpan(0, 0, 30));
                                });
                            options.ConfigureKeyVault(kv => {
                                kv.SetCredential(credential);
                            });
                        });
                    })
                .UseStartup<Startup>());
    }
}
