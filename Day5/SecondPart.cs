using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Day5.Models;

namespace Day5
{
    public static class SecondPart
    {
        private const int MatrixSize = 1000;
        public static int GetResult(string[] fileLines)
        {
            var matrix = new int[MatrixSize,MatrixSize];
            
            var coordinates = GetCoordinates(fileLines);

            foreach (var coordinate in coordinates)
            {
                if(string.IsNullOrEmpty(coordinate.CommonAxis.Key)) SetDiagonal(matrix, coordinate);
                else SetVerticalAndHorizontal(matrix, coordinate);
            }
            
            var result = GetResult(matrix);
            
            return result;
        }

        private static void SetVerticalAndHorizontal(int[,] matrix,Coordinate coordinate)
        {
            for (var i = coordinate.Start; i <= coordinate.End; i++)
            {
                if(coordinate.CommonAxis.Key == "X") matrix[coordinate.CommonAxis.Value, i]++;
                else matrix[i, coordinate.CommonAxis.Value]++;
            }
        }

        private static void SetDiagonal(int[,] matrix,Coordinate coordinate)
        {
            var x = coordinate.X1;
            var y = coordinate.Y1;
                
            while (true)
            {
                if (x == coordinate.X2 || y == coordinate.Y2)
                {
                    matrix[x, y]++;
                    break;
                }
                    
                matrix[x, y]++;
                    
                x += (int)coordinate.XChange;
                y += (int)coordinate.YChange;
            }
        }

        private static List<Coordinate> GetCoordinates(string[] fileLines)
        {
            var validCoordinates = fileLines
                .Select(l => l.Replace(" ", "").Split("->"))
                .Select(l => new Coordinate(l))
                .ToList();

            return validCoordinates;
        }

        private static int GetResult(int[,] matrix)
        {
            var result = 0;

            for (var x = 0; x < MatrixSize; x++)
            {
                for (var y = 0; y < MatrixSize; y++)
                {
                    if (matrix[x, y] >= 2) result++;
                }
            }

            return result;
        }
        
        private static void PrintResult(int[,] matrix)
        {
            for (var y = 0; y < MatrixSize; y++)
            {
                var line = new StringBuilder();

                for (var x = 0; x < MatrixSize; x++)
                {
                    line.Append($"{matrix[x, y]} ");
                }
                
                Console.WriteLine(line);
            }
        }
    }
}