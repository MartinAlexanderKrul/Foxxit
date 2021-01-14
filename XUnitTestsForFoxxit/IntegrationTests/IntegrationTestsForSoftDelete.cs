using Foxxit;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestsForFoxxit
{
    /*    public class IntegrationTestsForSoftDelete : IClassFixture<WebApplicationFactory<Startup>>
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
                DbContext.Users.Add(TestUser);
                DbContext.SaveChanges();

                Assert.NotNull(TestUser);

                DbContext.Users.Remove(TestUser);
                await DbContext.SaveChangesAsync();

                var user = DbContext.Users.FirstOrDefault();

                Assert.Null(user);
            }
        }*/
}