using System.Collections.Generic;
using System.Linq;
using Day13.Services;

namespace Day13
{
    public static class FirstPart
    {
        public static int GetResult(string[] fileLines)
        {
            var coordinates = CoordinateService.GetCoordinates(fileLines).ToList();

            var folding = FoldingService.GetFolding(fileLines);

            var pointsCount = new List<int>();
            
            foreach (var (axis, value) in folding)
            {
                coordinates = FoldingService.Fold(coordinates, value, axis).ToList();
                
                pointsCount.Add(coordinates.Count);
                
                //PrintPage(coordinates);
            }

            return pointsCount.First();
        }
    }
}