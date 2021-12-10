using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public static class FirstAndSecondPart
    {
        public static double GetResult(IEnumerable<string> fileLines, int days)
        {
            var fishes = fileLines
                .First()
                .Split(',')
                .Select(l => Convert.ToInt32(l))
                .ToList();

            var fishTimers = GetInitialFishesTimers(fishes);

            for (var i = 0; i < days; i++)
            {
                var newBorn = fishTimers[0];
                fishTimers[0] = fishTimers[1];
                fishTimers[1] = fishTimers[2];
                fishTimers[2] = fishTimers[3];
                fishTimers[3] = fishTimers[4];
                fishTimers[4] = fishTimers[5];
                fishTimers[5] = fishTimers[6];
                fishTimers[6] = fishTimers[7] + newBorn;
                fishTimers[7] = fishTimers[8];
                fishTimers[8] = newBorn;
            }

            var result = fishTimers
                .Sum(f => f.Value);

            return result;
        }

        private static Dictionary<int, double> GetInitialFishesTimers(List<int> fishes)
        {
            var fishTimers = new Dictionary<int, double>
            {
                { 0, 0 }, { 1, 0 }, { 2, 0 },
                { 3, 0 }, { 4, 0 }, { 5, 0 },
                { 6, 0 }, { 7, 0 }, { 8, 0 }
            };
            
            foreach (var fish in fishes) 
                fishTimers[fish]++;

            return fishTimers;
        }
    }
}