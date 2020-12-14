//using Foxxit;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace XUnitTestsForFoxxit
//{
//    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
//    {
//        private readonly WebApplicationFactory<Startup> factory;

//        public IntegrationTests(WebApplicationFactory<Startup> factory)
//        {
//            this.factory = factory;
//        }

//        #region Sample Test
//        [Fact]
//        public async Task Doubling_ReturnsResult()
//        {
//            //Arrange
//            var expected = 10;
//            var response = await factory.CreateClient().GetAsync("doubling?input=5");
//            var data = await response.Content.ReadAsStringAsync();

//            //Act
//            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(data);
//            result.TryGetValue("result", out int actual);

//            //Assert
//            response.EnsureSuccessStatusCode();
//            Assert.Equal(expected, actual);
//        }
//        #endregion

//    }
//}