using Foxxit.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestsForFoxxit
{
    public class TestBootstrapper
    {
        public static DbContextOptions<ApplicationDbContext> GetInMemoryDbContextOptions(string dbType = "InMemory")
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbType)
                .Options;

            return options;
        }
    }
}
