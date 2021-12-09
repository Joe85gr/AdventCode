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
            var matchesFound = new Dictionary<(int Row, int Col), bool>
            {
                {(lowestPoint.Row, lowestPoint.Col), true}
            };
            
            var locationsToCheck = new List<(int Row, int Col)>
            {
                lowestPoint
            };

            while (locationsToCheck.Count > 0)
            {
                var coordinates = locationsToCheck.First();
                
                CheckRow(coordinates, locationsToCheck, matrix, matchesFound, Direction.Right);
                CheckRow(coordinates, locationsToCheck, matrix, matchesFound, Direction.Left);
                
                CheckCol(coordinates, locationsToCheck, matrix, matchesFound, Direction.Up);
                CheckCol(coordinates, locationsToCheck, matrix, matchesFound, Direction.Down);

                locationsToCheck.Remove(coordinates);
            }

            return matchesFound.Count;
        }

        private static void CheckCol((int Row, int Col) coordinates, List<(int Row, int Col)> pointsToCheck,
            List<List<int>> matrix, Dictionary<(int Row, int Col), bool> matchesFound, Direction direction)
        {
            var x = coordinates.Row;
            var y = coordinates.Col;

            var currentNum = matrix[y][x];

            var coefficient = direction switch
            {
                Direction.Up => -1,
                Direction.Down => 1,
                _ => throw new Exception("Direction not implemented")
            };
            
            var i = 1;
            
            while (true)
            {
                var nextNum = matrix[y + (i * coefficient)][x];

                var nextNumFlows = (currentNum + 1 == nextNum || currentNum - 1 == nextNum) && nextNum < 9;
                
                if(nextNumFlows == false) break;
                var key = (x, y + (i * coefficient));
                
                if (matchesFound.ContainsKey(key) == false)
                {
                    matchesFound.Add(key, true);
                    pointsToCheck.Add(key);
                };

                currentNum = nextNum;
                
                i++;
            }
        }

        private static void CheckRow((int Row, int Col) coordinates, List<(int Row, int Col)> pointsToCheck, 
            List<List<int>> matrix, Dictionary<(int Row, int Col), bool> matchesFound, Direction direction)
        {
            var x = coordinates.Row;
            var y = coordinates.Col;

            var currentNum = matrix[y][x];

            var coefficient = direction switch
            {
                Direction.Left => -1,
                Direction.Right => 1,
                _ => throw new Exception("Direction not implemented")
            };
            
            var i = 1;
            
            while (true)
            {
                var nextNum = matrix[y][x + (i * coefficient)];

                var nextNumFlows = (currentNum + 1 == nextNum || currentNum - 1 == nextNum) && nextNum < 9;
                
                if(nextNumFlows == false) break;
                var key = (x + (i * coefficient), y);

                if (matchesFound.ContainsKey(key) == false)
                {
                    matchesFound.Add(key, true);
                    pointsToCheck.Add(key);
                };

                currentNum = nextNum;
                
                i++;
            }
            
        }
        

        private static List<List<int>> CreateMatrix(IReadOnlyList<string> fileLines)
        {
            var topAndBottomRow = new List<int>();

            //  Adds dummy 9 rows and columns :D
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