using System;
using System.Text.Json.Serialization;
using Foxxit.Database;
using Foxxit.Enums;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services;
using Foxxit.Services.EntityServices;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        public static void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None)
            {
                var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
                options.SameSite = SameSiteMode.Unspecified;
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
                options.OnAppendCookie = cookieContext =>
                    CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext =>
                    CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            });

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

            services.AddTransient<UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<SubRedditRepository>();
            services.AddTransient<ISubRedditService, SubRedditService>();

            services.AddTransient<PostRepository>();
            services.AddTransient<IPostService, PostService>();

            services.AddTransient<CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddTransient<NotificationRepository>();
            services.AddTransient<INotificationService, NotificationService>();

            services.AddTransient<UserSubRedditRepository>();
            services.AddTransient<IUserSubRedditService, UserSubRedditService>();

            services.AddTransient<ImageRepository>();
            services.AddTransient<IImageService, ImageService>();

            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IMailService, MailService>();

            services.AddTransient<VoteRepository>();
            services.AddTransient<IVoteService, VoteService>();

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
                options.User.RequireUniqueEmail = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use((context, next) =>
            {
                if (context.Request.Headers["x-forwarded-proto"] == "https")
                {
                    context.Request.Scheme = "https";
                }

                return next();
            });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}