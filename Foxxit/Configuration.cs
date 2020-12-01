using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit
{
    public class Configuration
    {
        public static Enum DbType { get { return GetEnvironmentVariableAsEnum("DbType"); } }
        public static string ConnectionString { get { return GetEnvironmentVariableAsString("MyDbConnection"); } }

        public static Enum GetEnvironmentVariableAsEnum(string variable)
        {
            return Enum.Parse<DatabaseType>(GetEnvironmentVariableAsString(variable));
        }

        public static string GetEnvironmentVariableAsString(string variable)
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