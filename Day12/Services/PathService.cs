using System.Collections.Generic;
using System.Linq;
using Library;

namespace Day12.Services
{
    public static class PathService
    {
        public static bool OneSmallCaveCanBeVisitedTwice = false;
        public static IEnumerable<string> FindPaths(string[] allPairs, string pathSoFar, Dictionary<string, int> alreadyProcessed)
        {
            var paths = new HashSet<string>();

            var splitPath = pathSoFar.Split('-');
            
            var end = splitPath[^1];

            var pairsLeft = new List<string>();

            pairsLeft = OneSmallCaveCanBeVisitedTwice 
                ? GetAllPairs2(allPairs, alreadyProcessed, end).ToList() : 
                GetAllPairs1(allPairs, alreadyProcessed, end).ToList();
            
            if (char.IsLower(end[^1]))
                if (alreadyProcessed.ContainsKey(end))
                    alreadyProcessed[end]++;
                else alreadyProcessed.Add(end, 1);

            foreach (var pair in pairsLeft)
            {
                var processedSoFar = new Dictionary<string, int>();
                processedSoFar.AddRange(alreadyProcessed);
                
                var orderedPair = OrderPair(pair, end);
                if (orderedPair == $"{end}-end") paths.Add(pathSoFar + "-end");
                else if (pair.Contains("end") == false)
                {
                    var charToAdd = orderedPair.Split('-')[^1];
                    paths.UnionWith(FindPaths(allPairs, $"{pathSoFar}-{charToAdd}", processedSoFar));
                }
            }
            
            return paths;
        }

        public static string OrderPair(string pathLeft, string firstPart)
        {
            var splitPair = pathLeft.Split('-');
            var secondPart = splitPair[0] == firstPart ? splitPair[1] : splitPair[0];
            
            return firstPart + "-" + secondPart;
        }

        private static IEnumerable<string> GetAllPairs1(IEnumerable<string> allPairs, Dictionary<string, int> alreadyProcessed, string end)
        {
             return allPairs
                .Where(p => p.Contains(end) && alreadyProcessed.Any(a => p.Split('-').Contains(a.Key)) == false)
                .ToList();
        }
        
        private static IEnumerable<string> GetAllPairs2(string[] allPairs, Dictionary<string, int> alreadyProcessed, string end)
        {
            var smallCaveAlreadyVisitedTwice = alreadyProcessed
                .Where(a => a.Key.Contains("start") == false && a.Key.Contains("end") == false)
                .Any(a => a.Value > 1);

            if (smallCaveAlreadyVisitedTwice)
            {
                return allPairs
                    .Where(p => p.Contains(end) && alreadyProcessed.Any(a => p.Split('-').Contains(a.Key)) == false);
            }

            return allPairs.Where(p => p.Contains(end) && p.Contains("start") == false);
        }
    }
}