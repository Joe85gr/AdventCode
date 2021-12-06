using System.Collections.Generic;
using System.Linq;
using Day5.Models;

namespace Day5.Services
{
    public static class CoordinatesService
    {
        public static IEnumerable<Coordinate> GetCoordinates(string[] fileLines)
        {
            var validCoordinates = fileLines
                .Select(l => l.Replace(" ", "").Split("->"))
                .Select(l => new Coordinate(l));

            return validCoordinates;
        }
    }
}