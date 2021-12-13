using System.Collections.Generic;
using System.Linq;

namespace Day13.Services
{
    public static class CoordinateService
    {
        public static IEnumerable<(int X, int Y)> GetCoordinates(IEnumerable<string> fileLines)
        {
            var coordinates = fileLines
                .Where(l => l.Contains("fold") == false && string.IsNullOrEmpty(l) == false)
                .Select(ToCoordinate);

            return coordinates;
        }
        
        private static (int X, int Y) ToCoordinate(string line)
        {
            var coordinate = line.Split(',');
            return (int.Parse(coordinate[0]), int.Parse(coordinate[1]));
        }
    }
}