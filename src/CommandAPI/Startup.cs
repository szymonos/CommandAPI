using System;
using System.IO;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CommandAPI.Configuration;
using CommandAPI.Data;

namespace CommandAPI {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            //SECTION 1. Add code below
            services.Configure<CmdApiSettings>(Configuration.GetSection("Settings"));
            services.AddAzureAppConfiguration();
            services.AddControllers();
            services.AddScoped<ICommandApiRepo, MockCommandApiRepo>();

            //swagger
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(options => {
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Assembly.GetExecutingAssembly().GetName().Name);
            });

            app.UseAzureAppConfiguration();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                //SECTION 2. Add code below
                endpoints.MapControllers();
            });
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
