using System.Collections.Generic;
using System.Linq;
using Day11.Services;
using Library;

namespace Day11
{
    public static class SecondPart
    {
        public static double GetResult(string[] fileLines)
        {
            var energyMap = MatrixUtility
                .WrapMatrix(fileLines, 10)
                .ToList();
            
            var allOctopuses = fileLines
                .Select(a => a.Length)
                .Sum();
            
            var steps = 0;
            
            while (true)
            {
                var flashed = new HashSet<(int x, int y)>();
                
                DumboOctopusesService.StartStep(energyMap, flashed);

                steps++;
                
                if(flashed.Count == allOctopuses) break;
            }

            return steps;
        }
    }
}