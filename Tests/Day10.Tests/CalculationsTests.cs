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

            const int expected = 26397;
            var actual = Calculations.GetTotalErrorScore(errorLines);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("{{[[({([", 288957)]
        [InlineData("({<[{(", 5566)]
        [InlineData("{{<{<((((", 1480781)]
        [InlineData("[[{{[{[{<", 995444)]
        [InlineData("[({<", 294)]
        public void GetTotalAutoCompleteScore_ReturnsCorrectScore(string incompleteLine, int expected)
        {
            var actual = Calculations.GetTotalAutoCompleteScore(incompleteLine);

            Assert.Equal(expected, actual);
        }
    }
}