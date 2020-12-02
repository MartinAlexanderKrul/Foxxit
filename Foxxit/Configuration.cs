using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit
{
    public class Configuration
    {
        public static Enum DbType { get { return Enum.Parse<DatabaseType>(GetEnvironmentVariable("DbType")); } }
        public static string ConnectionString { get { return GetEnvironmentVariable("MyDbConnection"); } }

        public static string SendGridApiKey { get { return GetEnvironmentVariable("SENDGRID_API_KEY"); } }

        public static string GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.User);
        }
    }

    internal enum DatabaseType
    {
        MSSQL,
        SQLite,
        Heroku
    }
}