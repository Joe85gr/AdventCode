using System.Linq;
using Day9.Services;
using Library;

namespace Day9
{
    public static class FirstPart
    {
        public static int GetResult(string[] fileLines)
        {
            var matrix = MatrixUtility
                .WrapMatrix(fileLines, 9)
                .ToList();

            var lowestPoints = CoordinatesService
                .GetLowestPointsCoordinates(matrix)
                .ToList();

            var result = lowestPoints
                .Sum(lowestPoint => 1 + matrix[lowestPoint.Col][lowestPoint.Row]);

            return result;
        }
    }
}