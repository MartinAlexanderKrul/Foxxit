using Xunit;
using Foxxit.Extensions;

namespace XUnitTestsForFoxxit
{
    public class StringExtensionUnitTests01
    {
        [Fact]
        public void Contains()
        {
            string text = "Martin Alexander Krul";

            var actualOutput = text.Contains("ALEX");
            var expectedOutput = false;

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ContainsCaseInsensitive()
        {
            string text = "Martin Alexander Krul";

            var actualOutput = text.ContainsCaseInsensitive("ALEX");
            var expectedOutput = true;

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}