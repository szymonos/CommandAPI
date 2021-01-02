using System;
using System.IO;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using AutoMapper;

using CommandAPI.Configuration;
using CommandAPI.Data;

using Npgsql;

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

            var builder = new NpgsqlConnectionStringBuilder {
                ConnectionString = Configuration.GetConnectionString("CmdDbPgsql"),
                Username = Configuration["Settings:DB:UserID"],
                Password = Configuration["Settings:DB:Password"]
            };
            services.AddDbContext<CommandContext>
                (options => options.UseNpgsql(builder.ConnectionString));

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICommandApiRepo, SqlCommandApiRepo>();

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
