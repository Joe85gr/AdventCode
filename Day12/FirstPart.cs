using System.Collections.Generic;
using System.Linq;
using Day12.Services;

namespace Day12
{
    public class FirstPart
    {
        public static int GetResult(string[] fileLines)
        {
            var startPoints = fileLines
                .Where(l => l.Contains("start"))
                .ToList();

            var result = 0;
            
            foreach (var startPoint in startPoints)
            {
                var currentPath = PathService.GetNextCave(startPoint, "start");
                result+= PathService.FindPaths(fileLines, new HashSet<string>(), currentPath, false);
            }
            
            return result;
        }
    }
}