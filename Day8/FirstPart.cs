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

            var uniqueNumberSegments = new int[] {2, 3, 4, 7};

            var result = 0;

            foreach (var line in patterns)
            {
                var output = line[1].Split(' ');

                result += output
                    .Count(value => uniqueNumberSegments.Contains(value.Length));
            }

            return result;
        }
    }
}