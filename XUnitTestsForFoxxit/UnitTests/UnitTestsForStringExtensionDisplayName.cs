using Xunit;
using Foxxit.Extensions;

namespace XUnitTestsForFoxxit
{
    public class StringExtensionUnitTests02
    {
        [Fact]
        public void ShortenDisplayName_FullName()
        {
            string text = "Martin Alexander Krul";

            var actualOutput = text.ShortenDisplayName();
            var expectedOutput = "Martin Alexan...";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ShortenDisplayName_StringEmpty()
        {
            string text = string.Empty;

            var actualOutput = text.ShortenDisplayName();
            var expectedOutput = string.Empty;

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ShortenDisplayName_Null()
        {
            string text = null;

            var actualOutput = text.ShortenDisplayName();
            string expectedOutput = string.Empty;

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ShortenDisplayName_FullNameWithAt()
        {
            string text = "MartinAlexanderKrul@GreenFoxAcademy.COM";

            var actualOutput = text.ShortenDisplayName();
            string expectedOutput = "MartinAlexand...";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ShortenDisplayName_ShortName()
        {
            string text = "GFA";

            var actualOutput = text.ShortenDisplayName();
            string expectedOutput = "GFA";

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}