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

            var result = 0;
            
            foreach (var startPoint in startPoints)
            {
                var currentPath = PathService.OrderPair(startPoint, "start").Split('-')[1];
                result+= PathService.FindPaths(fileLines, new List<string>(), currentPath);
            }
            
            return result;
        }
    }
}