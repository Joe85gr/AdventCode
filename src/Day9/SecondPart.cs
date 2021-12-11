using System.Collections.Generic;
using System.Linq;
using Day9.Services;
using Library;

namespace Day9
{
    public static class SecondPart
    {
        public static int GetResult(string[] fileLines)
        {
            var matrix = MatrixUtility
                .WrapMatrix(fileLines, 9)
                .ToList();

            var lowestPointCoordinates = CoordinatesService.GetLowestPointsCoordinates(matrix);
            
            var basins = lowestPointCoordinates
                .Select(lowestPoint => GetBasin(lowestPoint, matrix)).ToList();

            var result = basins.OrderByDescending(x => x)
                .Take(3)
                .Aggregate(1, (total, value) => total * value);

            return result;
        }

        private static int GetBasin((int Row, int Col) lowestPoint, List<List<int>> matrix)
        {
            var alreadyChecked = new Dictionary<(int Row, int Col), bool>();

            var (row, col) = lowestPoint;
            var count = CheckAdjacent(matrix, row, col, alreadyChecked);

            return count;
        }

        private static int CheckAdjacent(IReadOnlyList<List<int>> matrix, int x, int y, 
            IDictionary<(int Row, int Col), bool> alreadyChecked)
        {
            var count = 1;
            var currentNum = matrix[y][x];
            alreadyChecked[(x, y)] = true;
            
            //  Check Right
            if(currentNum < matrix[y][x + 1] && matrix[y][x + 1] < 9)
                if(alreadyChecked.ContainsKey((x + 1,y)) == false)
                    count+=CheckAdjacent(matrix,x + 1, y, alreadyChecked);
            // Check Left
            if(currentNum < matrix[y][x - 1] && matrix[y][x - 1] < 9)
                if(alreadyChecked.ContainsKey((x - 1,y)) == false)
                    count+=CheckAdjacent(matrix,x - 1, y, alreadyChecked);
            // Check Down
            if((currentNum < matrix[y + 1][x] || currentNum + 1 == matrix[y + 1][x]) && matrix[y + 1][x] < 9)
                if(alreadyChecked.ContainsKey((x,y + 1)) == false)
                    count+=CheckAdjacent(matrix,x,y + 1, alreadyChecked);
            // Check Up
            if(currentNum < matrix[y - 1][x] && matrix[y - 1][x] < 9)
                if(alreadyChecked.ContainsKey((x,y - 1)) == false)
                    count+=CheckAdjacent(matrix,x, y - 1, alreadyChecked);

            return count;
        }
    }
}