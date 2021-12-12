using System.Collections.Generic;
using System.Linq;
using Day11.Services;
using Library;

namespace Day11
{
    public static class FirstPart
    {
        private const int Steps = 100;
        public static double GetResult(string[] fileLines)
        {
            var energyMap = MatrixUtility
                .WrapMatrix(fileLines, 10)
                .ToList();

            var flashes = 0d;

            for (var i = 0; i < Steps; i++)
            {
                var flashed = new HashSet<(int x, int y)>();
                
                flashes+=OctopusService.StartStep(energyMap, flashed);
            }
            
            return flashes;
        }
    }
}