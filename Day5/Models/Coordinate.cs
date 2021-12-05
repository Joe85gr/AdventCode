using System;
using System.Collections.Generic;

namespace Day5.Models
{
    public class Coordinate
    {
        public Coordinate(IReadOnlyList<string> lines)
        {
            var firstCoordinate = lines[0].Split(',');
            var secondCoordinate = lines[1].Split(',');

            X1 = Convert.ToInt32(firstCoordinate[0]);
            Y1 = Convert.ToInt32(firstCoordinate[1]);
            X2 = Convert.ToInt32(secondCoordinate[0]);
            Y2 = Convert.ToInt32(secondCoordinate[1]);
          
            if (X1 == X2)
            {
                Start = Math.Min(Y1, Y2);
                End = Math.Max(Y1, Y2);
                CommonAxis = new KeyValuePair<string, int>("X", X1);
            }
            else if (Y1 == Y2)
            {
                Start = Math.Min(X1, X2);
                End = Math.Max(X1, X2);
                CommonAxis = new KeyValuePair<string, int>("Y", Y1);
            }
            else
            {
                XChange = X1 > X2 ? GridDirection.Decrease : GridDirection.Increase;
                YChange = Y1 > Y2 ? GridDirection.Decrease : GridDirection.Increase;
            }
        }

        public GridDirection XChange { get; }
        public GridDirection YChange { get; }
        public int X1 { get; }
        public int X2 { get; }
        public int Y1 { get; }
        public int Y2 { get; }
        public KeyValuePair<string, int> CommonAxis { get; }
        public int Start { get; }
        public int End { get; }
    }
}