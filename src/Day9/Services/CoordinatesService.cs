using System.Collections.Generic;
using System.Linq;

namespace Day9.Services
{
    public static class CoordinatesService
    {
        public static IEnumerable<(int Row, int Col)> GetLowestPointsCoordinates(IReadOnlyList<List<int>> matrix)
        {
            var lowestPointsCoordinates = new List<(int Row, int Col)>();
            
            for (var y = 1; y < matrix.Count - 1; y++)
            {
                for (var x = 1; x < matrix[0].Count - 1; x++)
                {
                    var currentNumber = matrix[y][x];
                    if (currentNumber == 9) continue;
                    
                    var min = new[]
                    {
                        matrix[y-1][x],
                        matrix[y][x-1], currentNumber, matrix[y][x+1],
                        matrix[y+1][x]
                    }.Min();
                    
                    if (min == currentNumber) lowestPointsCoordinates.Add((x,y));
                }
            }

            return lowestPointsCoordinates;
        }
    }
}