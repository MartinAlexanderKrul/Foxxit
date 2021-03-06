using System;
using System.Net;
using Foxxit.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

namespace Foxxit
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (Configuration.DbType.Equals(DatabaseType.Heroku))
            {
                Log.Logger = new LoggerConfiguration()
                           .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                           .Enrich.FromLogContext()
               .WriteTo.Email(new EmailConnectionInfo()
               {
                   NetworkCredentials = new NetworkCredential("foxxit2020@gmail.com", Configuration.GetEnvironmentVariable("Email_Password")),
                   FromEmail = "foxxit2020@gmail.com",
                   ToEmail = "foxxit2020@yahoo.com",
                   EmailSubject = "Log Email",
                   EnableSsl = true,
                   Port = 465,
                   MailServer = "smtp.gmail.com",
               })
               .CreateLogger();
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                           .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                           .Enrich.FromLogContext()
                           .WriteTo.File("LocalLog.xml")
                           .CreateLogger();
            }

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}