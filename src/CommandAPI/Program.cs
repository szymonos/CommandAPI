using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CommandAPI
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var settings = config.Build();
                        var appcfEndpoint = System.Environment.GetEnvironmentVariable("APPCF_ENDPOINT");
                        var credential = new DefaultAzureCredential();
                        config.AddAzureAppConfiguration(options =>
                        {
                            options.Connect(new Uri(appcfEndpoint), credential)
                                .Select("Settings:*", hostingContext.HostingEnvironment.EnvironmentName);
                        });
                    })
                .UseStartup<Startup>());
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
