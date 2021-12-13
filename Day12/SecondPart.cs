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
                .ToList();
            
            var allPaths = new HashSet<string>();

            PathService.OneSmallCaveCanBeVisitedTwice = true;
            
            foreach (var startPoint in startPoints)
            {
                var alreadyProcessed = new Dictionary<string, int>() {{"start", 1}};
                var pathSoFar = PathService.OrderPair(startPoint, "start");
                var startPointPaths = PathService.FindPaths(fileLines, pathSoFar, alreadyProcessed);
                
                allPaths.UnionWith(startPointPaths);
            }
            
            var result = allPaths.Count;

            return result;
        }
    }
}