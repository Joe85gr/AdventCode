using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Day7
{
    public class FirstPart
    {
        public static int GetResult(string[] fileLines)
        {
            var crabs = fileLines.First()
                .Split(',')
                .Select(int.Parse)
                .ToList();

            var totalFuels = new Dictionary<int, int>();

            for (var i = 0; i < crabs.Count; i++)
            {
                if(totalFuels.ContainsKey(crabs[i]) == false) totalFuels.Add(crabs[i], 0);
                else continue;

                for (var j = 0; j < crabs.Count; j++)
                {
                    if (j == i) continue;

                    var (min, max) = crabs[i] > crabs[j] ? (crabs[j], crabs[i]) : (crabs[i], crabs[j]);

                    var fuelSpent = max - min;
                    
                    totalFuels[crabs[i]] += fuelSpent;

                }
            }

            var result = totalFuels.Min(t => t.Value);

            return result;
        }
    }
}