using System;
using System.Collections.Generic;
using System.Linq;
using Day5.Models;

namespace Day5
{
    public static class FirstPart
    {
        private const int MatrixSize = 1000;
        public static int GetResult(string[] fileLines)
        {
            var matrix = new int[MatrixSize,MatrixSize];
            
            var coordinates = GetCoordinates(fileLines);

            foreach (var coordinate in coordinates)
            {
                for (var i = coordinate.Start; i <= coordinate.End; i++)
                {
                    if(coordinate.CommonAxis.Key == "X") matrix[coordinate.CommonAxis.Value, i]++;
                    else matrix[i, coordinate.CommonAxis.Value]++;
                }
            }

            var result = GetResult(matrix);
            return result;
        }

        private static IEnumerable<Coordinate> GetCoordinates(string[] fileLines)
        {
            var validCoordinates = fileLines
                .Select(l => l.Replace(" ", "").Split("->"))
                .Select(l => new Coordinate(l))
                .Where(l => string.IsNullOrEmpty(l.CommonAxis.Key) == false)
                .ToList();

            return validCoordinates;
        }
        
        private static int GetResult(int[,] matrix)
        {
            var result = 0;

            for (var i = 0; i < MatrixSize; i++)
            {
                for (var z = 0; z < MatrixSize; z++)
                {
                    if (matrix[i, z] > 1) result++;
                }
            }

            return result;
        }
    }
}