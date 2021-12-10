using Day10.Domain;
using Xunit;

namespace Tests.Day10.Tests
{
    public class CalculationsTests
    {
        [Fact]
        public void GetTotalErrorScore_ReturnsCorrectScore()
        {
            var errorLines = new[]
            {
                '}', ')', ']',
                ')', '>'
            };

            var expected = 26397;
            var actual = Calculations.GetTotalErrorScore(errorLines);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("{{[[({([", 288957)]
        public void GetTotalAutoCompleteScore_ReturnsCorrectScore(string incompleteLine, int expected)
        {
            var actual = Calculations.GetTotalAutoCompleteScore(incompleteLine);

            Assert.Equal(expected, actual);
        }
    }
}