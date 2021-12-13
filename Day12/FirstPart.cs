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
                var processed = new Dictionary<string, int>() {{"start", 1}};
                var pathSoFar = PathService.OrderPair(startPoint, "start");
                var startPointPaths = PathService.FindPaths(fileLines, pathSoFar, processed);
                
                allPaths.UnionWith(startPointPaths);
            }
            
            var result = allPaths
                .Count(p => p.Replace("start", "").Replace("end", "").ToCharArray().Any(char.IsLower));

            return result;
        }
    }
}