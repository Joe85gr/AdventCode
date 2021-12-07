using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public static class SecondPart
    {
        public static double GetResult(IEnumerable<string> fileLines)
        {
            var crabs = fileLines.First()
                .Split(',')
                .Select(int.Parse)
                .ToList();

            var minPosition = crabs.Min();
            var maxPosition = crabs.Max();
            
            var totalFuels = Enumerable
                .Range(minPosition, maxPosition + 1)
                .ToDictionary(key => key, _=> (double)0);

            for (var i = 0; i < totalFuels.Count; i++)
            {
                foreach (var crab in crabs)
                {
                    var steps = Math.Abs(crab - i);
                    var currentConsumption = 1;

                    for (var k = 0; k < steps; k++)
                    {
                        totalFuels[i] += currentConsumption;
                        currentConsumption++;
                    }
                }
            }

            var result = totalFuels.Min(t => t.Value);

            return result;
        }
    }
}