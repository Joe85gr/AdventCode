using System.Collections.Generic;
using System.Linq;
using Day12.Services;

namespace Day12
{
    public class SecondPart
    {
        public static int GetResult(string[] fileLines)
        {
            var startPoints = fileLines
                .Where(l => l.Contains("start"))
                .ToArray();
            
            PathService.OneSmallCaveCanBeVisitedTwice = true;

            var result = 0;
            foreach (var startPoint in startPoints)
            {
                var currentCave = PathService.GetNextCave(startPoint, "start");
                result+= PathService.FindPaths(fileLines, new HashSet<string>(), currentCave, false);
            }
            
            return result;
        }
    }
}