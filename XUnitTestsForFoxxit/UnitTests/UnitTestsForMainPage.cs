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
            var twoDaysAgo = new DateTime(2020, 12, 11, 10, 00, 00);
            var post = new Post() { CreatedAt = twoDaysAgo };

            var actualOutput = service.GetTimeStamp(post);
            var expectedOutput = "15 minutes ago";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void HoursTest()
        {
            var service = new MainPageViewModelService();
            var twoDaysAgo = new DateTime(2020, 12, 11, 8, 45, 00);
            var post = new Post() { CreatedAt = twoDaysAgo };

            var actualOutput = service.GetTimeStamp(post);
            var expectedOutput = "1 hour ago";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DaysTest()
        {
            var service = new MainPageViewModelService();
            var twoDaysAgo = new DateTime(2020, 12, 9, 8, 00, 00);
            var post = new Post() { CreatedAt = twoDaysAgo };

            var actualOutput = service.GetTimeStamp(post);
            var expectedOutput = "2 days ago";

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}