using System;
using System.Collections.Generic;
using System.Linq;
using Day7.Services;

namespace Day7
{
    public static class FirstPart
    {
        public static int GetResult(IEnumerable<string> fileLines)
        {
            var crabs = CrabService
                .GetCrabs(fileLines)
                .ToList();

            var totalFuels = new Dictionary<int, int>();

            for (var i = 0; i < crabs.Count; i++)
            {
                if(totalFuels.ContainsKey(crabs[i]) == false) totalFuels.Add(crabs[i], 0);
                else continue;

                for (var j = 0; j < crabs.Count; j++)
                {
                    if (j == i) continue;

                    var fuelSpent = Math.Abs(crabs[i] - crabs[j]);
                    
                    totalFuels[crabs[i]] += fuelSpent;
                }
            }

            var result = totalFuels.Min(t => t.Value);

            return result;
        }
    }
}