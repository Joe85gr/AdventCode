using System.Collections.Generic;
using System.Linq;
using Day12.Services;

namespace Day12
{
    public class FirstPart
    {
        public int GetResult(string[] fileLines)
        {
            var startPoints = fileLines
                .Where(l => l.Contains("start"))
                .ToList();

            var allPaths = new HashSet<string>();

            foreach (var startPoint in startPoints)
            {
                var pathSoFar = PathService.OrderPair(startPoint, "start");
                var alreadyProcessed = new HashSet<string>{"start"};
                var startPointPaths = PathService.FindPaths(fileLines, pathSoFar, alreadyProcessed);
                
                allPaths.UnionWith(startPointPaths);
            }
            
            var result = allPaths
                .Count(p => p.Replace("start", "").Replace("end", "").ToCharArray().Any(char.IsLower));

            return result;
        }
    }
}