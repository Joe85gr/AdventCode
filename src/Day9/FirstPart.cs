using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    public static class FirstPart
    {
        public static int GetResult(string[] fileLines)
        {
            var matrix = CreateMatrix(fileLines);
            
            var result = 0;
            
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
                    
                    if (min == currentNumber) result += 1 + min;
                }
            }

            return result;
        }

        private static List<List<int>> CreateMatrix(IReadOnlyList<string> fileLines)
        {
            var topAndBottomRow = new List<int>();

            //  Adds dummy 9 rows and columns
            for (var i = 0; i < fileLines[0].Length + 2; i++)
            {
                topAndBottomRow.Add(9);
            }
            
            var matrix = new List<List<int>> {topAndBottomRow};

            foreach (var line in fileLines)
            {
                var lineToAdd = new List<int> {9};
                var rawLine = line.Select(c => c - '0').ToList();
                lineToAdd.AddRange(rawLine);
                lineToAdd.Add(9);
                matrix.Add(lineToAdd);
            }
            matrix.Add(topAndBottomRow);

            return matrix;
        }
    }
}