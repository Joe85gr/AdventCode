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
                .Select(r => new [] {r, 0})
                .ToArray();
            
            for (var i = 0; i < totalFuels.Length; i++)
            {
                foreach (var crab in crabs)
                {
                    var steps = Math.Abs(crab - i);
                    var currentConsumption = 1;
                    var total = 0;

                    for (var k = 0; k < steps; k++)
                    {
                        total += currentConsumption;
                        currentConsumption++;
                    }

                    totalFuels[i][1] += total;
                }
            }

            var result = totalFuels.Min(t => t[1]);

            return result;
        }
    }
}