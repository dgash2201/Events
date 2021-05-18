using System;
using System.Diagnostics;
using Events.Data;
using Events.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using Events.Data.Database;

namespace Events
{ 
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            //string envType = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //if (string.IsNullOrEmpty(envType))
            //{
            //    envType = Debugger.IsAttached ? "Development" : "Release";
            //}

            //string settingsName = envType == "Development" ? "appsettings.Development.json" : "appsettings.json";

            //IConfigurationBuilder builder = new ConfigurationBuilder()
            //    .AddJsonFile(settingsName, false, true);

            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _configuration.Bind(new AppSettings());

            services
                .RegisterLogicServices()
                .Configure<AppSettings>(_configuration)
                .AddMongoDb(_configuration.GetConnectionString("DatabaseConnection"))
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<IEventRepository, EventRepository>()
                .AddSwaggerGen(o =>
                {
                    o.SwaggerDoc("v1", new OpenApiInfo() { Title = "Events", Version = "1" });
                })
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(c => c.MapControllers());
            app.UseSwagger().UseSwaggerUI(o => o.SwaggerEndpoint("v1/swagger.json", "Events"));
        }
    }
}
