using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit
{
    internal enum DatabaseType
    {
        MSSQL,
        SQLite,
        Heroku,
    }

    public class Configuration
    {
        public static Enum DbType
        {
            get { return Enum.Parse<DatabaseType>(GetEnvironmentVariable("DbType")); }
        }

        public static string ConnectionString
        {
            get { return GetEnvironmentVariable("MyDbConnection"); }
        }

        public static string SendGridApiKey
        {
            get { return GetEnvironmentVariable("SENDGRID_API_KEY"); }
        }

        public static string GoogleClientId
        {
            get { return GetEnvironmentVariable("GoogleClientId"); }
        }

        public static string GoogleClientSecret
        {
            get { return GetEnvironmentVariable("GoogleClientSecret"); }
        }

        public static string FacebookClientId
        {
            get { return GetEnvironmentVariable("FacebookClientId"); }
        }

        public static string FacebookClientSecret
        {
            get { return GetEnvironmentVariable("FacebookClientSecret"); }
        }

        public static string TwitterClientId
        {
            get { return GetEnvironmentVariable("TwitterClientId"); }
        }

        public static string TwitterClientSecret
        {
            get { return GetEnvironmentVariable("TwitterClientSecret"); }
        }

        public static string GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
        }
    }
}