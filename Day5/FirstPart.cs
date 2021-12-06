using System.Collections.Generic;
using System.Linq;
using Day5.Domain;
using Day5.Models;
using Day5.Services;

namespace Day5
{
    public static class FirstPart
    {
        private const int MatrixSize = 1000;
        public static int GetResult(string[] fileLines)
        {
            var matrix = new int[MatrixSize,MatrixSize];
            
            var coordinates = CoordinatesService
                .GetCoordinates(fileLines)
                .Where(l => string.IsNullOrEmpty(l.CommonAxis.Key) == false);

            foreach (var coordinate in coordinates)
            {
                Matrix.SetVerticalAndHorizontalPoints(matrix, coordinate);
            }

            var result = Calculations.GetResult(matrix);
            return result;
        }
    }
}