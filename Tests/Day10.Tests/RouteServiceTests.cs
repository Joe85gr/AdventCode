using Day10.Services;
using Xunit;

namespace Tests.Day10.Tests
{
    public class RouteServiceTests
    {
        private readonly RouteService _routeService;
        
        public RouteServiceTests()
        {
            _routeService = new  RouteService();
        }
        
        [Theory]
        [InlineData("{([(<{}[<>[]}>{[]{[(<()>",'}')]
        [InlineData("[[<[([]))<([[{}[[()]]]",')')]
        [InlineData("[{[{({}]{}}([{[{{{}}([]",']')]
        [InlineData("[<(<(<(<{}))><([]([]()",')')]
        [InlineData("<{([([[(<>()){}]>(<<{{",'>')]
        public void GetFirstCorruptedChar_ReturnsCorrectCorruptedChar(string errorChunk, char expected)
        {
            var actual = _routeService.GetFirstCorruptedChar(errorChunk);

            Assert.Equal(expected, actual);
        }
    }
}