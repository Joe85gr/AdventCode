using System.Collections.Generic;
using System.Linq;
using Library;

namespace Day12.Services
{
    public static class PathService
    {
        public static bool OneSmallCaveCanBeVisitedTwice = false;

        public static int FindPaths(string[] allPairs, Dictionary<string, byte> smallCaves, string currentCave)
        {
            var count = 0;

            var pathsLeft = SearchPathsLeft(allPairs, smallCaves, currentCave);

            CheckIfSmallCaveVisitedTwice(smallCaves, currentCave);
            
            foreach (var pair in pathsLeft)
            {
                var nextCave = GetNextCave(pair, currentCave);

                var thisPathSmallCaves = new Dictionary<string, byte>();
                thisPathSmallCaves.AddRange(smallCaves);

                if (nextCave == "end")
                {
                    if (OneSmallCaveCanBeVisitedTwice) count++;
                    else if (thisPathSmallCaves.Any()) count++;
                }
                else count+=FindPaths(allPairs, thisPathSmallCaves, nextCave);
            }

            return count;
        }
        
        public static string GetNextCave(string pathLeft, string currentCave)
        {
            var splitPair = pathLeft.Split('-');
            var nextCave = splitPair[0] == currentCave ? splitPair[1] : splitPair[0];

            return nextCave;
        }
        
        private static IEnumerable<string> SearchPathsLeft(IEnumerable<string> allPairs, Dictionary<string, byte> smallCaves, string currentCave)
        {
            var linkedPaths = allPairs
                .Where(p => p.Contains("start") == false && p.Contains(currentCave));

            List<string> pathsLeft;

            var smallCaveVisitedTwice = CheckIfSmallCaveVisitedTwice(smallCaves);
            
            if (OneSmallCaveCanBeVisitedTwice == false || smallCaveVisitedTwice)
                pathsLeft = linkedPaths
                    .Where(p => smallCaves.Any(s => p.Split('-').Contains(s.Key)) == false)
                    .ToList();
            else pathsLeft = linkedPaths.Select(l => l).ToList();

            return pathsLeft;
        }

        private static void CheckIfSmallCaveVisitedTwice(IDictionary<string, byte> smallCaves, string currentCave)
        {
            if (char.IsLower(currentCave[0]) == false) return;
            
            if (smallCaves.ContainsKey(currentCave))
                smallCaves[currentCave] = 1;
            else
                smallCaves.Add(currentCave, 0);
        }
        
        private static bool CheckIfSmallCaveVisitedTwice(Dictionary<string, byte> smallCaves)
        {
            return smallCaves.ContainsValue(1);
        }
    }
}