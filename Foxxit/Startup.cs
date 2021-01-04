using System;
using System.Text.Json.Serialization;
using Foxxit.Database;
using Foxxit.Enums;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using UserRole = Foxxit.Models.Entities.UserRole;

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

            services.AddIdentity<User, UserRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<MailService>();

            services.AddTransient<UserRepository>();
            services.AddTransient<UserService>();

            services.AddTransient<SubRedditRepository>();
            services.AddTransient<ISubRedditService, SubRedditService>();

            services.AddTransient<PostRepository>();
            services.AddTransient<IPostService, PostService>();

            services.AddTransient<CommentRepository>();

            services.AddTransient<NotificationRepository>();
            services.AddTransient<INotificationService, NotificationService>();

            services.AddTransient<ISearchService, SearchService>();

            services.AddAuthentication()
                .AddGoogle("google", options =>
                {
                    options.ClientId = Configuration.GoogleClientId;
                    options.ClientSecret = Configuration.GoogleClientSecret;
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddFacebook("facebook", options =>
                {
                    options.ClientId = Configuration.FacebookClientId;
                    options.ClientSecret = Configuration.FacebookClientSecret;
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddTwitter("twitter", options =>
                {
                    var twitterAuth = Config.GetSection("Authentication:Twitter");

                    options.ConsumerKey = Configuration.TwitterClientId;
                    options.ConsumerSecret = Configuration.TwitterClientSecret;
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                services.AddTransient<MailService>();
                services.AddIdentity<User, UserRole>(options => options.SignIn.RequireConfirmedEmail = true)
                        .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();

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

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}