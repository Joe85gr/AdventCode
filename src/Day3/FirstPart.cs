using System.Collections.Generic;
using System.Linq;
using System.Text;
using Day3.Domain;

namespace Day3
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

            var gamma = CustomConvert.BitsToInt(mostCommon); 
            var epsilon = CustomConvert.BitsToInt(leastCommon);

            var result = gamma * epsilon;

            return result;
        }
        
        private static IEnumerable<char> GetDigitCount(IEnumerable<char> digits)
        {
            return digits.GroupBy(d => d)
                .OrderByDescending(d => d.Count())
                .Select(d => d.Key);
        }
    }
}