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

            var (axis, foldingValue) = FoldingService.GetAllFolding(fileLines).First();

            var pointsCount = new List<int>();
            
            coordinates = FoldingService.Fold(coordinates, foldingValue, axis).ToList();
            
            pointsCount.Add(coordinates.Count);
            
            return pointsCount.First();
        }
    }
}