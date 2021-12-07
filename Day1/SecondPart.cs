using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public static class SecondPart
    {
        public static int GetResult(IEnumerable<string> fileLines)
        {
            var depths = fileLines.Select(x => Convert.ToInt32(x)).ToList();

            var count = 0;
            
            var previousDepthsSum = depths[0] + depths[1] + depths[2];

            var reminder = depths.Count % 3;
            
            for (var i = 1; i < depths.Count - reminder; i++)
            {
                var currentDepthsSum = depths[i] + depths[i + 1] + depths[i + 2];
                
                if (currentDepthsSum > previousDepthsSum) count++;

                previousDepthsSum = currentDepthsSum;
            }

            return count;
        }
    }
}