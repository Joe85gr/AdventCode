using System;
using System.Collections.Generic;
using System.Linq;
using Day7.Domain;

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

            var preCalculatedFuels = new Dictionary<int, int>();
            
            for (var i = 0; i < totalFuels.Length; i++)
            {
                foreach (var steps in crabs.Select(crab => Math.Abs(crab - i)))
                {
                    if (preCalculatedFuels.ContainsKey(steps))
                    {
                        totalFuels[i][1] += preCalculatedFuels[steps];
                    }
                    else
                    {
                        var total = Calculations.CalculateTriangle(steps);
                        totalFuels[i][1] += Calculations.CalculateTriangle(steps);
                        preCalculatedFuels.Add(steps, total);
                    }
                }
            }

            var result = totalFuels.Min(t => t[1]);

            return result;
        }
    }
}