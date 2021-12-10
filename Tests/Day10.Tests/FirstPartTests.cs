using System.IO;
using Day10;
using Xunit;

namespace Tests.Day10.Tests
{
    public class FirstPartTests
    {
        private FirstPart _firstPart = new ();
        
        [Fact]
        public void GetResult_ReturnsCorrectTotalErrorScore()
        {
            var fileLines = File.ReadAllLines("MockData.txt");

            var expected = 26397;
            var actual = _firstPart.GetResult(fileLines);
            
            Assert.Equal(expected, actual);
        }
    }
}