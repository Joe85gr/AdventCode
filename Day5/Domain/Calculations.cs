using System;

namespace Day5.Domain
{
    public static class Calculations
    {
        public static int GetResult(int[,] matrix)
        {
            var result = 0;
            var matrixSize = Math.Sqrt(matrix.Length);

            for (var y = 0; y < matrixSize; y++)
            {
                for (var x = 0; x < matrixSize; x++)
                {
                    if (matrix[y, x] >= 2) result++;
                }
            }

            return result;
        }
    }
}