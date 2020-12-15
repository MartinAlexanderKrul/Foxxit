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
    public class IntegrationTestsForSoftDelete : IClassFixture<WebApplicationFactory<Startup>>
    {
        public IntegrationTestsForSoftDelete()
        {
            DbContext = new ApplicationDbContext(TestBootstrapper.GetInMemoryDbContextOptions("InMemory"));
            TestUser = new User()
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
        }

        public ApplicationDbContext DbContext { get; set; }
        public User TestUser { get; set; }

        [Fact]
        public async Task MockDb_AddNewUser()
        {
            await DbContext.Users.AddAsync(TestUser);
            await DbContext.SaveChangesAsync();

            var expected = 1;
            var actual = DbContext.Users.Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task SoftDelete_SetsIsDeletedAsTrue()
        {
            await MockDb_AddNewUser();

            DbContext.Users.Remove(TestUser);
            await DbContext.SaveChangesAsync();

            var expected = true;
            var actual = DbContext.Users.Any(u=>u.IsDeleted == true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SoftDelete_DoesntWorkAsItemIsHardDeletedInstead()
        {
            var testUser = new User()
            {
                UserName = "Pepa",
                DisplayName = "PEPA",
                Email = "pepa@test.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            DbContext.Users.Add(testUser);
            DbContext.Users.Remove(testUser);
            DbContext.SaveChanges();

            var expected = 0;
            var actual = DbContext.Users.Count();

            Assert.Equal(expected, actual);
        }
    }
}