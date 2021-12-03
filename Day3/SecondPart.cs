using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Day3
{
    public static class SecondPart
    {
        public static int GetResult(string[] fileLines)
        {
            var mostCommon = fileLines;
            var leastCommon = fileLines;
            
            var digitCount = fileLines[0].Length;
            
            for (var i = 0; i < digitCount; i++)
            {
                var mostCommonGroups = GroupValues(mostCommon
                    .Select(x => x[i].ToString()));
                
                var leastCommonGroups = GroupValues(leastCommon
                    .Select(x => x[i].ToString()));
                
                var mostCommonNumber = GetMostCommonNumber(mostCommonGroups);
                var leastCommonNumber = GetLeastCommonNumber(leastCommonGroups);

                if(mostCommon.Length > 1)
                    mostCommon = FilterValues(mostCommon, i, mostCommonNumber);
                
                if(leastCommon.Length > 1)
                    leastCommon = FilterValues(leastCommon, i, leastCommonNumber);
            }

            var oxigenRating  = Convert.ToInt32(mostCommon.First(), 2);
            var co2Rating = Convert.ToInt32(leastCommon.First(), 2);

            var result = oxigenRating * co2Rating;
            
            return result;
        }

        private static string[] FilterValues(string[] numbers, int i, string filterCriteria)
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

        private static string GetMostCommonNumber(Dictionary<string, int> numberGroups)
        {
            if (numberGroups["0"] == numberGroups["1"]) return "1";
            
            return numberGroups
                .OrderByDescending(g => g.Value)
                .First()
                .Key;
        }
        
        private static string GetLeastCommonNumber(Dictionary<string, int> numberGroups)
        {
            if (numberGroups["0"] == numberGroups["1"]) return "0";
            
            return numberGroups
                .OrderByDescending(g => g.Value)
                .Last()
                .Key;
        }
    }
}