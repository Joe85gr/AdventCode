using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace Day12.Services
{
    public static class PathService
    {
        public static bool OneSmallCaveCanBeVisitedTwice = false;

        public static int FindPaths(string[] allPairs, List<string> smallCaves, string currentCave)
        {
            var count = 0;
            
            var linkedPaths = allPairs
                .Where(p => p.Contains("start") == false && p.Contains(currentCave));

            List<string> pathsLeft;

            var smallCaveVisitedTwice = CheckIfSmallCaveVisitedTwice(smallCaves);

            if (OneSmallCaveCanBeVisitedTwice == false || smallCaveVisitedTwice)
                pathsLeft = linkedPaths
                    .Where(p => smallCaves.Any(s => p.Split('-').Contains(s)) == false)
                    .ToList();
            else pathsLeft = linkedPaths.Select(l => l).ToList();

            if(char.IsLower(currentCave[0])) smallCaves.Add(currentCave);
            
            foreach (var pair in pathsLeft)
            {
                var orderedPair = OrderPair(pair, currentCave).Split('-');
                var nextCave = orderedPair[1];

                var thisPathSmallCaves = new List<string>();
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
        public static string OrderPair(string pathLeft, string firstPart)
        {
            var splitPair = pathLeft.Split('-');
            var secondPart = splitPair[0] == firstPart ? splitPair[1] : splitPair[0];

            return firstPart + "-" + secondPart;
        }
        
        private static bool CheckIfSmallCaveVisitedTwice(List<string> smallCaves)
        {
            var hash = new string[smallCaves.Count];

            for (var i = 0; i < smallCaves.Count; i++)
            {
                if (hash.Contains(smallCaves[i])) return true;
                hash[i] = smallCaves[i];
            }

            return false;
        }
        
    }
}