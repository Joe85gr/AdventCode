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
            var newCoordinates = axis == Axis.X ? coordinates.Where(x => x.X < foldValue).ToHashSet()
                : coordinates.Where(x => x.Y < foldValue).ToHashSet();
                
            var coordinatesMoving = axis == Axis.X ? coordinates.Where(x => x.X > foldValue).ToHashSet()
                : coordinates.Where(x => x.Y > foldValue).ToHashSet();
            
            foreach (var coordinate in coordinatesMoving)
            {
                ValueTuple<int, int> newCoordinate;
                
                if(axis == Axis.Y)
                    newCoordinate = new ValueTuple<int, int>(coordinate.X, Math.Abs(foldValue-(coordinate.Y - foldValue)));
                else newCoordinate = new ValueTuple<int, int>(Math.Abs(foldValue - (coordinate.X - foldValue)), coordinate.Y);

                newCoordinates.Add(newCoordinate);
            }
            
            return newCoordinates;
        }

        public static IEnumerable<(Axis Axis, int Value)>  GetFolding(IEnumerable<string> fileLines)
        {
            return fileLines.Where(l => l.Contains("fold"))
                .Select(l => l.Replace("fold along ", ""))
                .Select(s => s.Split('='))
                .Select(s => (s[0] == "x" ? Axis.X : Axis.Y, int.Parse(s[1])));
        }
        

    }
}