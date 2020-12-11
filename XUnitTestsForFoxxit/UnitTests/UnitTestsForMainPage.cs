using Foxxit.Models.Entities;
using Foxxit.Services.ViewModelServices;
using System;
using Xunit;

namespace XUnitTestsForFoxxit
{
    public class MainPageUnitTest
    {
        [Fact]
        public void MinutesTest()
        {
            var service = new MainPageViewModelService();
            var date = DateTime.Now.AddMinutes(-15);
            var post = new Post() { CreatedAt = date };

            var actualOutput = service.GetTimeStamp(post);
            var expectedOutput = "15 minutes";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void HoursTest()
        {
            var service = new MainPageViewModelService();
            var date = DateTime.Now.AddHours(-1);
            var post = new Post() { CreatedAt = date };

            var actualOutput = service.GetTimeStamp(post);
            var expectedOutput = "1 hour";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DaysTest()
        {
            var service = new MainPageViewModelService();
            var date = DateTime.Now.AddDays(-12);
            var post = new Post() { CreatedAt = date };

            var actualOutput = service.GetTimeStamp(post);
            var expectedOutput = "12 days";

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}