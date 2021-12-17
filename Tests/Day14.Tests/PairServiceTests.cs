using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day14.Services;
using FluentAssertions;
using Xunit;

namespace Tests.Day14.Tests
{
    public class PairServiceTests
    {
        [Fact]
        public void GetPairInsertions_ReturnsCorrectPair()
        {
            var fileLines = new[] {"","", "CH -> B", "HH -> N"};

            var expected = new Dictionary<string, char>() {{"CH", 'B'}, {"HH", 'N'}};
            
            var actual = PairService.GetPairInsertions(fileLines).ToList();

            actual.Should().Equal(expected);

        }

        [Theory]
        [InlineData(10, 1588)]
        [InlineData(40, 2188189693529)]
        public void ProcessPairs_ReturnsCorrect_MaxAndMinLetterCount(int steps, double expectedDifference)
        {
            var fileLines = File.ReadAllLines("Day14_MockData.txt");
            var polymerTemplate = fileLines.First();
    
            var lettersCount = LetterService.GetCurrentLetters(polymerTemplate);
            var pairsToProcess = PairService.GetPairsToProcess(polymerTemplate);
            var pairInsertions = PairService.GetPairInsertions(fileLines);

            for (var i = 0; i < steps; i++)
            {
                pairsToProcess = PairService.ProcessPairs(pairsToProcess, lettersCount, pairInsertions);
            }

            var difference = lettersCount.Max(l => l.Value) - lettersCount.Min(l => l.Value);

            difference.Should().Be(expectedDifference);
        }
        
    }
}