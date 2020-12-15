﻿using Foxxit;
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
    public class IntegrationTestsBasic : IClassFixture<WebApplicationFactory<Startup>>
    {
        public IntegrationTestsBasic()
        {
            DbContext = new ApplicationDbContext(TestBootstrapper.GetInMemoryDbContextOptions("InMemory"));
        }

        public ApplicationDbContext DbContext { get; set; }

        [Fact]
        public void InMemoryDb_WorkingProperly()
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

            var expected = "Jan";
            var actual = DbContext.Users.FirstOrDefault(u => u.Email == "jan@test.com").UserName;

            Assert.Equal(expected, actual);
        }


        #region Sample Test
        //[Fact]
        //public async Task Doubling_ReturnsResult()
        //{
        //    //Arrange
        //    var expected = 10;
        //    var response = await factory.CreateClient().GetAsync("doubling?input=5");
        //    var data = await response.Content.ReadAsStringAsync();

        //    //Act
        //    var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(data);
        //    result.TryGetValue("result", out int actual);

        //    //Assert
        //    response.EnsureSuccessStatusCode();
        //    Assert.Equal(expected, actual);
        //}
        #endregion

    }
}