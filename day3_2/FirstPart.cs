using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day3_2
{
    public static class FirstPart
    {
        public static int GetResult(IEnumerable<string> fileLines)
        {
            var matrix = fileLines
                .Select(l => l.ToCharArray())
                .ToArray();

            var bits = matrix.First().Length;

            var mostCommon = new StringBuilder();
            var leastCommon = new StringBuilder();
            
            for (var i = 0; i < bits; i++)
            {
                var currentRow = matrix
                    .Select(m => m[i]);
                
                var occurrences = GetDigitCount(currentRow)
                    .ToArray();
                
                mostCommon.Append(occurrences.First());
                leastCommon.Append(occurrences.Last());
            }

            var gamma = BitsToInt(mostCommon); 
            var epsilon = BitsToInt(leastCommon);

            var result = gamma * epsilon;

            return result;
        }
        
        private static int BitsToInt(StringBuilder bits) => Convert.ToInt32(bits.ToString(), 2);
        private static IEnumerable<char> GetDigitCount(IEnumerable<char> digits)
        {
            var digit = digits.GroupBy(d => d)
                .OrderByDescending(d => d.Count())
                .Select(d => d.Key);

            return digit;
        }
    }
}