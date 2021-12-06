using System;
using System.Text;

namespace Day5.Domain
{
    public class Print
    {
        private static void PrintResult(int[,] matrix)
        {
            var matrixSize = Math.Sqrt(matrix.Length);
            
            for (var y = 0; y < matrixSize; y++)
            {
                var line = new StringBuilder();

                for (var x = 0; x < matrixSize; x++)
                {
                    line.Append($"{matrix[x, y]} ");
                }
                
                Console.WriteLine(line);
            }
        }
    }
}