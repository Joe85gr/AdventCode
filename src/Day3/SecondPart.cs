using System.Collections.Generic;
using System.Linq;
using Day3.Domain;

namespace Day3
{
    public static class SecondPart
    {
        public static int GetResult(string[] fileLines)
        {
            var mostCommon = GetMostCommon(fileLines);
            var leastCommon = GetLeastCommon(fileLines);
            
            var oxygenRating  = CustomConvert.BitsToInt(mostCommon);
            var co2Rating = CustomConvert.BitsToInt(leastCommon);

            var result = oxygenRating * co2Rating;
            
            return result;
        }

        private static string GetMostCommon(string[] mostCommon)
        {
            var i = 0;
            
            while (mostCommon.Length > 1)
            {
                var mostCommonGroups = GroupValues(mostCommon
                    .Select(x => x[i].ToString()));
                
                var mostCommonNumber = mostCommonGroups["0"] == mostCommonGroups["1"] 
                    ?  "1" : GetDigitCounts(mostCommonGroups).First().Key;

                if(mostCommon.Length > 1)
                    mostCommon = FilterValues(mostCommon, i, mostCommonNumber);
                
                i++;
            }

            return mostCommon.First();
        }
        private static string GetLeastCommon(string[] leastCommon)
        {
            var i = 0;
            
            while (leastCommon.Length > 1)
            {
                var leastCommonGroups = GroupValues(leastCommon
                    .Select(x => x[i].ToString()));
                
                var leastCommonNumber = leastCommonGroups["0"] == leastCommonGroups["1"] 
                    ? "0" :  GetDigitCounts(leastCommonGroups).Last().Key;

                if(leastCommon.Length > 1)
                    leastCommon = FilterValues(leastCommon, i, leastCommonNumber);

                i++;
            }

            return leastCommon.First();
        }
        private static string[] FilterValues(IEnumerable<string> numbers, int i, string filterCriteria)
        {
            return numbers
                .Where(l => l[i].ToString().Equals(filterCriteria))
                .ToArray();
        }
        private static Dictionary<string, int> GroupValues(IEnumerable<string> values)
        {
            var groups = values
                .GroupBy(n => n)
                .ToDictionary(n => n.Key, n => n.Count());

            return groups;
        }

        private static IEnumerable<KeyValuePair<string, int>> GetDigitCounts(IReadOnlyDictionary<string, int> numberGroups)
        {
             return numberGroups.OrderByDescending(g => g.Value);
        }
    }
}