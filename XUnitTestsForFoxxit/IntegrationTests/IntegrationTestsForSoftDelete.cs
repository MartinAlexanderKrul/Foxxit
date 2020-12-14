using Foxxit;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestsForFoxxit
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        public IntegrationTests()
        {
            DbContext = new ApplicationDbContext(TestBootstrapper.GetInMemoryDbContextOptions("InMemory"));
        }

        public ApplicationDbContext DbContext { get; set; }

        [Fact]
        public void SoftDelete_SetsIsDeletedAsTrue()
        {
            var testUser = new User()
            {
                UserName = "Jan",
                DisplayName = "JAN",
                Email = "jan@test.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            DbContext.Users.Add(testUser);
            DbContext.SaveChanges();

            DbContext.Users.Remove(testUser);
            DbContext.SaveChanges();

            var expected = true;
            var actual = DbContext.Users.FirstOrDefault(u => u.Email == "jan@test.com").IsDeleted;

            Assert.Equal(expected, actual);
        }
    }
}