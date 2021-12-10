using System.IO;
using Day10;
using Xunit;

namespace Tests.Day10.Tests
{
    public class SecondPartTests
    {
        private readonly SecondPart _secondPart = new ();
        
        [Fact]
        public void GetResult_ReturnsCorrectTotalErrorScore()
        {
            var fileLines = File.ReadAllLines("MockData.txt");

            const int expected = 288957;
            var actual = _secondPart.GetResult(fileLines);
            
            Assert.Equal(expected, actual);
        }
    }
}