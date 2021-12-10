using System.Collections.Generic;
using System.Linq;

namespace Day8
{
    public static class FirstPart
    {
        public static double GetResult(IEnumerable<string> fileLines)
        {

            var patterns = fileLines
                .Select(l => l.Split(" | "));

            var uniqueNumberSegments = new [] {2, 3, 4, 7};

            return patterns
                .Select(line => line[1].Split(' '))
                .Select(output => output.Count(value => uniqueNumberSegments.Contains(value.Length)))
                .Sum();
        }
    }
}