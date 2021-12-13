using System;
using System.Collections.Generic;
using System.Linq;
using Day13.Models;

namespace Day13.Services
{
    public static class FoldingService
    {
        public static IEnumerable<(int X, int Y)>  Fold(List<(int X, int Y)> coordinates, int foldValue, Axis axis)
        {
            var newCoordinates = GetStaticPoints(coordinates, foldValue, axis).ToHashSet();
                
            var coordinatesMoving = GetFoldingPoints(coordinates, foldValue, axis).ToList();
            
            foreach (var (x, y) in coordinatesMoving)
            {
                var newCoordinate = axis == Axis.Y 
                    ? new ValueTuple<int, int>(x, Math.Abs(foldValue- (y - foldValue))) 
                    : new ValueTuple<int, int>(Math.Abs(foldValue - (x - foldValue)), y);

                newCoordinates.Add(newCoordinate);
            }
            
            return newCoordinates;
        }

        public static IEnumerable<(Axis Axis, int Value)>  GetAllFolding(IEnumerable<string> fileLines)
        {
            return fileLines.Where(l => l.Contains("fold"))
                .Select(l => l.Replace("fold along ", ""))
                .Select(s => s.Split('='))
                .Select(s => (s[0] == "x" ? Axis.X : Axis.Y, int.Parse(s[1])));
        }

        private static IEnumerable<(int X, int Y)> GetStaticPoints(IEnumerable<(int X, int Y)> coordinates, int foldValue, Axis axis)
        {
            return axis == Axis.X 
                ? coordinates.Where(x => x.X < foldValue).ToHashSet()
                : coordinates.Where(x => x.Y < foldValue).ToHashSet();
        }
        
        private static IEnumerable<(int X, int Y)> GetFoldingPoints(IEnumerable<(int X, int Y)> coordinates, int foldValue,Axis axis)
        {
            return axis == Axis.X 
                ? coordinates.Where(x => x.X > foldValue).ToList()
                : coordinates.Where(x => x.Y > foldValue).ToList();
        }
    }
}