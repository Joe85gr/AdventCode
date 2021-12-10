using System.Collections.Generic;
using System.Linq;

namespace Day9.Services
{
    public static class FloorMapService
    {
        public static List<List<int>> CreateMatrix(IReadOnlyList<string> fileLines)
        {
            var topAndBottomRow = new List<int>();

            //  Adds dummy 9 rows and columns to make life easier :D
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