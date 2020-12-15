using Foxxit.Models.Entities;
using System;
using Xunit;
using Foxxit.Extensions;

namespace XUnitTestsForFoxxit
{
    public class PostBaseExtensionUnitTests
    {
        [Fact]
        public void MinutesTest()
        {
            var date = DateTime.Now.AddMinutes(-15);
            var post = new Post() { CreatedAt = date };

            var actualOutput = post.TimeStamp();
            var expectedOutput = "15 minutes";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void HoursTest()
        {
            var date = DateTime.Now.AddHours(-1);
            var post = new Post() { CreatedAt = date };

            var actualOutput = post.TimeStamp();
            var expectedOutput = "1 hour";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void DaysTest()
        {
            var date = DateTime.Now.AddDays(-12);
            var post = new Post() { CreatedAt = date };

            var actualOutput = post.TimeStamp();
            var expectedOutput = "12 days";

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}