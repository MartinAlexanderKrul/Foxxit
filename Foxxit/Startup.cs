using Foxxit.Database;
using Foxxit.Services;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foxxit
{
    public class Startup
    {
        public IConfiguration Config { get; set; }

        public Startup(IConfiguration config)
        {
            Config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            string environmentDbType = Environment.GetEnvironmentVariable("DbType", EnvironmentVariableTarget.User);
            var dbType = !string.IsNullOrEmpty(environmentDbType)
                                    ? environmentDbType
                                    : Config.GetValue<string>("DatabaseSettings");

            var environmentConnectionString = Environment.GetEnvironmentVariable("MyDbConnection", EnvironmentVariableTarget.User);
            var connectionString = !string.IsNullOrEmpty(environmentConnectionString)
                                    ? environmentConnectionString
                                    : Config.GetConnectionString("DefaultConnection");

            switch (dbType)
            {
                case "MSSQL":
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Config.GetConnectionString(connectionString)));
                    break;

                case "SQLite":
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Config.GetConnectionString(connectionString)));
                    break;

                case "Heroku":
                    services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Config.GetConnectionString(connectionString)));
                    break;
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}