using System;
using System.Linq;
using Day13.Models;
using Day13.Services;

namespace Day13
{
    public static class SecondPart
    {
        public static void PrintResult(string[] fileLines)
        {
            var coordinates = CoordinateService.GetCoordinates(fileLines).ToList();

            var folding = FoldingService.GetAllFolding(fileLines).ToList();

            foreach (var (axis, value) in folding)
            {
                coordinates = FoldingService.Fold(coordinates, value, axis).ToList();
            }

            Console.WriteLine("Day 13 - Second Part result:");
            Print.PrintPage(coordinates);
        }
    }
}