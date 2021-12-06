using Day5.Models;

namespace Day5.Domain
{
    public static class Matrix
    {
        public static void SetVerticalAndHorizontalPoints(int[,] matrix,Coordinate coordinate)
        {
            for (var i = coordinate.Start; i <= coordinate.End; i++)
            {
                if(coordinate.CommonAxis.Key == "X") matrix[coordinate.CommonAxis.Value, i]++;
                else matrix[i, coordinate.CommonAxis.Value]++;
            }
        }

        public static void SetDiagonalPoints(int[,] matrix,Coordinate coordinate)
        {
            var x = coordinate.X1;
            var y = coordinate.Y1;
                
            while (true)
            {
                matrix[x, y]++;
                    
                if (x == coordinate.X2 || y == coordinate.Y2) break;

                x += (int)coordinate.XChange;
                y += (int)coordinate.YChange;
            }
        }
    }
}