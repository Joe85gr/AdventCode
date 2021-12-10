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

            var outputValues = GetOutputValue(patterns);

            var result = outputValues.Sum();
            
            return result;
        }

        private static IEnumerable<int> GetOutputValue(IEnumerable<string[]> patterns)
        {
            var uniqueNumberSegments = new [] {2, 3, 4, 7};

            return patterns
                .Select(line => line[1].Split(' '))
                .Select(output => output.Count(value => uniqueNumberSegments.Contains(value.Length)));
        }
    }
}