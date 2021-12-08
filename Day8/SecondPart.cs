using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Day8.Extensions;

namespace Day8
{
    public static class SecondPart
    {
        private const string AllChars = "abcdefg";
        public static double GetResult(IEnumerable<string> fileLines)
        {
            var patterns = fileLines
                .Select(l => l.Split(" | "));

            var uniqueNumberSegments = new Dictionary<int, int>()
            {
                {2, 1}, {4, 4},
                {3, 7}, {7, 8},
            };

            var result = 0d;

            foreach (var line in patterns)
            {
                var pattern = line[0]
                    .Split(' ')
                    .Select(SortString)
                    .ToArray();
                
                var output = line[1]
                    .Split(' ')
                    .Select(SortString)
                    .ToArray();
                
                var patternLeft  = line[0]
                    .Split(' ')
                    .Select(SortString)
                    .ToDictionary(w => w, _=> true);
                
                var numberMaps = new Dictionary<int, string>();

                foreach (var number in pattern)
                {
                    var digits = number.Length;
                    if (uniqueNumberSegments.ContainsKey(digits))
                    {
                        numberMaps.Add(uniqueNumberSegments[digits], number);
                        patternLeft.Remove(number);
                    }
                }

                var sixPartialPattern = RemoveChars(AllChars, numberMaps[7]);
                var sixPattern = pattern
                    .First(p => sixPartialPattern.All(p.Contains) && p.Length != 7);
                
                numberMaps.Add(6, sixPattern);
                patternLeft.Remove(sixPattern);

                FindNumberPattern(patternLeft, numberMaps, 7,2, 3);
                FindNumberPattern(patternLeft, numberMaps, 6,0, 5);
                FindNumberPattern(patternLeft, numberMaps, 5,1, 9);
                FindNumberPattern(patternLeft, numberMaps, 3,1, 2);

                var zeroPattern = patternLeft.First().Key;
                
                numberMaps.Add(0, zeroPattern);

                var reversedNumberMaps = numberMaps.ReverseDictionary();

                var finalNumberString = new StringBuilder();
                foreach (var num  in output)
                {
                    finalNumberString.Append(reversedNumberMaps[num]);
                }

                var partialTotal = Convert.ToDouble(finalNumberString.ToString());
                result += partialTotal;
            }

            return result;
        }

        private static void FindNumberPattern(Dictionary<string, bool> patternLeft, Dictionary<int, string> numberMaps, int criteria1, int criteria2, int number)
        {
            var pattern = string.Empty;

            foreach (var pair in patternLeft)
            {
                var chrLeft = RemoveChars(pair.Key, numberMaps[criteria1]).Length;
                
                if (chrLeft != criteria2) continue;
                pattern = pair.Key;
                break;
            }

            numberMaps.Add(number, pattern);
            patternLeft.Remove(pattern);
        }

        private static string RemoveChars(string from, string charsToRemove)
        {
            var builder = new StringBuilder();

            foreach (var chr in from)
            {
                if (charsToRemove.Contains(chr.ToString()) == false) builder.Append(chr);
            }

            return builder.ToString();
        }
        
        private static string SortString(string input)
        {
            var characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}