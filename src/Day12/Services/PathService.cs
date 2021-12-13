using System.Collections.Generic;
using System.Linq;

namespace Day12.Services
{
    public static class PathService
    {
        public static bool OneSmallCaveCanBeVisitedTwice = false;

        public static int FindPaths(string[] allPairs, HashSet<string> smallCaves, 
            string currentCave, bool smallCaveVisitedTwice)
        {
            var count = 0;

            var pathsLeft = SearchPathsLeft(allPairs, smallCaves, currentCave, smallCaveVisitedTwice).ToArray();

            if (smallCaveVisitedTwice == false) smallCaveVisitedTwice = smallCaves.Contains(currentCave);
            
            AddSmallCave(smallCaves, currentCave);
            
            foreach (var pair in pathsLeft)
            {
                var nextCave = GetNextCave(pair, currentCave);

                var thisPathSmallCaves = new HashSet<string>();
                thisPathSmallCaves.UnionWith(smallCaves);

                if (nextCave == "end")
                {
                    if (OneSmallCaveCanBeVisitedTwice) count++;
                    else if (thisPathSmallCaves.Any()) count++;
                }
                else count+=FindPaths(allPairs, thisPathSmallCaves, nextCave, smallCaveVisitedTwice);
            }

            return count;
        }
        
        public static string GetNextCave(string pathLeft, string currentCave)
        {
            var splitPair = pathLeft.Split('-');
            var nextCave = splitPair[0] == currentCave ? splitPair[1] : splitPair[0];

            return nextCave;
        }
        
        private static IEnumerable<string> SearchPathsLeft(IEnumerable<string> allPairs, HashSet<string> smallCaves, 
            string currentCave, bool smallCaveVisitedTwice)
        {
            var linkedPaths = allPairs
                .Where(p => p.Contains("start") == false && p.Contains(currentCave));

            List<string> pathsLeft;

            //var smallCaveVisitedTwice = CheckIfSmallCaveVisitedTwice(smallCaves);
            
            if (OneSmallCaveCanBeVisitedTwice == false || smallCaveVisitedTwice)
                pathsLeft = linkedPaths
                    .Where(p => smallCaves.Any(s => p.Split('-').Contains(s)) == false)
                    .ToList();
            else pathsLeft = linkedPaths.Select(l => l).ToList();

            return pathsLeft;
        }

        private static void AddSmallCave(ISet<string> smallCaves, string currentCave)
        {
            if (char.IsLower(currentCave[0]) == false) return;
            
            smallCaves.Add(currentCave);
        }
    }
}