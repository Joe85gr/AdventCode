using System;
using System.Collections.Generic;
using System.Linq;
using Day9.Models;

namespace Day9
{
    public static class SecondPart
    {
        public static int GetResult(string[] fileLines)
        {
            var matrix = CreateMatrix(fileLines);

            var lowestPointCoordinates = GetLowestPointsCoordinates(matrix);
            
            var basins = new List<int>();

            foreach (var lowestPoint in lowestPointCoordinates)
            {
                basins.Add(GetBasin(lowestPoint, matrix));
            }

            var top3Basin = basins.OrderByDescending(x => x)
                .Take(3)
                .ToArray();

            var result = 1;

            foreach (var basin in top3Basin)
            {
                result *= basin;
            }
            
            return result;
        }

        private static int GetBasin((int Row, int Col) lowestPoint, List<List<int>> matrix)
        {
            var alreadyChecked = new Dictionary<(int Row, int Col), bool>();
            
            var count = CheckAdiacent(matrix, lowestPoint.Row, lowestPoint.Col, alreadyChecked);

            return count;
        }

        private static int CheckAdiacent(List<List<int>> matrix, int x, int y, Dictionary<(int Row, int Col),bool> alreadyChecked)
        {
            var count = 1;
            var currentNum = matrix[y][x];
            alreadyChecked[(x, y)] = true;
            
            //  Check Right
            if((currentNum - 1 == matrix[y][x + 1] || currentNum + 1 == matrix[y][x + 1]) && matrix[y][x + 1] < 9)
                if(alreadyChecked.ContainsKey((x + 1,y)) == false)
                    count+=CheckAdiacent(matrix,x + 1, y, alreadyChecked);
            // Check Left
            if((currentNum - 1 == matrix[y][x - 1] || currentNum + 1 == matrix[y][x - 1]) && matrix[y][x - 1] < 9)
                if(alreadyChecked.ContainsKey((x - 1,y)) == false)
                    count+=CheckAdiacent(matrix,x - 1, y, alreadyChecked);
            // Check Down
            if((currentNum - 1 == matrix[y + 1][x] || currentNum + 1 == matrix[y + 1][x]) && matrix[y + 1][x] < 9)
                if(alreadyChecked.ContainsKey((x,y + 1)) == false)
                    count+=CheckAdiacent(matrix,x,y + 1, alreadyChecked);
            // Check Up
            if((currentNum - 1 == matrix[y - 1][x] || currentNum + 1 == matrix[y - 1][x]) && matrix[y - 1][x] < 9)
                if(alreadyChecked.ContainsKey((x,y - 1)) == false)
                    count+=CheckAdiacent(matrix,x, y - 1, alreadyChecked);

            return count;
        }

        //  Wraps the matrix with "99" to make life easier :D
        private static List<List<int>> CreateMatrix(IReadOnlyList<string> fileLines)
        {
            var topAndBottomRow = new List<int>();

            
            for (var i = 0; i < fileLines[0].Length + 2; i++)
            {
                topAndBottomRow.Add(99);
            }
            
            var matrix = new List<List<int>> {topAndBottomRow};

            foreach (var line in fileLines)
            {
                var lineToAdd = new List<int> {99};
                var rawLine = line.Select(c => c - '0').ToList();
                lineToAdd.AddRange(rawLine);
                lineToAdd.Add(99);
                matrix.Add(lineToAdd);
            }
            matrix.Add(topAndBottomRow);

            return matrix;
        }
        
        private static List<(int Row, int Col)> GetLowestPointsCoordinates(List<List<int>> matrix)
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