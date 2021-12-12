using System.Collections.Generic;
using System.Linq;

namespace Day12.Services
{
    public class PathService
    {
        public static IEnumerable<string> FindPaths(string[] allPairs, string pathSoFar, ISet<string> alreadyProcessed)
        {
            var paths = new HashSet<string>();

            var splitPath = pathSoFar.Split('-');
            
            var end = splitPath[^1];
            var pairsLeft = allPairs
                .Where(p => p.Contains(end) 
                            && alreadyProcessed.Any(a => p.Split('-').Contains(a)) == false)
                .ToList();
            
            if (char.IsLower(end[^1])) alreadyProcessed.Add(end);

            foreach (var pair in pairsLeft)
            {
                var pairAlreadyProcess = new HashSet<string>();
                pairAlreadyProcess.UnionWith(alreadyProcessed);
                
                var orderedPair = OrderPair(pair, end);
                if (orderedPair == $"{end}-end") paths.Add(pathSoFar + "-end");
                else if (pair.Contains("end") == false)
                {
                    var charToAdd = orderedPair.Split('-')[^1];
                    paths.UnionWith(FindPaths(allPairs, $"{pathSoFar}-{charToAdd}", pairAlreadyProcess));
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
    }
}