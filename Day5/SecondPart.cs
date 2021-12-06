using Day5.Domain;
using Day5.Services;

namespace Day5
{
    public static class SecondPart
    {
        private const int MatrixSize = 1000;
        public static int GetResult(string[] fileLines)
        {
            var matrix = new int[MatrixSize,MatrixSize];
            
            var coordinates = CoordinatesService.GetCoordinates(fileLines);

            foreach (var coordinate in coordinates)
            {
                if(string.IsNullOrEmpty(coordinate.CommonAxis.Key)) Matrix.SetDiagonalPoints(matrix, coordinate);
                else Matrix.SetVerticalAndHorizontalPoints(matrix, coordinate);
            }
            
            var result = Calculations.GetResult(matrix);
            
            return result;
        }
    }
}