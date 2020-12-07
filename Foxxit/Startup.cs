using System.Text.Json.Serialization;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Foxxit.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Foxxit
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            this.Config = config;
        }

        public IConfiguration Config { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            switch (Configuration.DbType)
            {
                case DatabaseType.MSSQL:
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
                    break;

                case DatabaseType.SQLite:
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.ConnectionString));
                    break;

                case DatabaseType.Heroku:
                    services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
                    break;
            }

            services.AddTransient<MailService>();
            services.AddIdentity<User, UserRole>(options => options.SignIn.RequireConfirmedEmail = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
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