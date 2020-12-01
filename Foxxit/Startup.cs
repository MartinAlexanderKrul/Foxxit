using Foxxit.Database;
using Foxxit.Models.Entities;
using Foxxit.Services;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Config.GetConnectionString("Main")));

            services.AddIdentity<UserModelxxx, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddGoogle("google", options =>
                {
                    var googleAuth = Config.GetSection("Authentication:Google");

                    options.ClientId = googleAuth["ClientId"];
                    options.ClientSecret = googleAuth["ClientSecret"];
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddFacebook("facebook", options =>
                {
                    var facebookAuth = Config.GetSection("Authentication:Facebook");

                    options.ClientId = facebookAuth["ClientId"];
                    options.ClientSecret = facebookAuth["ClientSecret"];
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddTwitter("twitter", options =>
                {
                    var twitterAuth = Config.GetSection("Authentication:Twitter");

                    options.ConsumerKey = twitterAuth["ConsumerAPIKey"];
                    options.ConsumerSecret = twitterAuth["ConsumerSecret"];
                });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
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