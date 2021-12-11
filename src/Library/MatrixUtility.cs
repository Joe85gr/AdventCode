using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public static class MatrixUtility
    {
        public static IEnumerable<List<int>> WrapMatrix(string[] fileLines, int wrapper)
        {
            var topAndBottomRow = new List<int>();
            
            for (var i = 0; i < fileLines[0].Length + 2; i++)
            {
                topAndBottomRow.Add(wrapper);
            }
            
            var matrix = new List<List<int>> {topAndBottomRow};

            foreach (var line in fileLines)
            {
                var lineToAdd = new List<int> {wrapper};
                var rawLine = line.Select(c => c - '0').ToList();
                lineToAdd.AddRange(rawLine);
                lineToAdd.Add(wrapper);
                matrix.Add(lineToAdd);
            }
            matrix.Add(topAndBottomRow);

            return matrix;
        }
        
        public static void PrintMatrix(IReadOnlyList<List<int>> energyMap)
        {
            Console.WriteLine("------------------");
            
            for (var y = 1; y < energyMap.Count - 1; y++)
            {
                for (var x = 1; x < energyMap[0].Count - 1; x++)
                {
                    Console.ForegroundColor = energyMap[y][x] == 0 ? ConsoleColor.Green : ConsoleColor.Black;
                    Console.Write($"{energyMap[y][x]} ");
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("------------------");
            
        }
    }
}