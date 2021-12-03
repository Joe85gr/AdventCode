﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day3
{
    internal static class Program
    {
        private const string FilePath = "Day3.txt";

        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);

            var digitCount = fileLines[0].Length;
            var mostCommonNumbers = new StringBuilder();
            var leastCommonNumbers = new StringBuilder();

            for (var i = 0; i < digitCount; i++)
            {
                var mostCommonNumber = GetMostCommonNumber(
                    fileLines.Select(x => x[i].ToString()));
                
                mostCommonNumbers.Append(mostCommonNumber);

                leastCommonNumbers.Append(mostCommonNumber == "1" ? "0" : "1");
            }
            
            var gammaRate = Convert.ToInt32(mostCommonNumbers.ToString(), 2);
            var epsilonRate = Convert.ToInt32(leastCommonNumbers.ToString(), 2);
            var result = gammaRate * epsilonRate;
            
            Console.WriteLine(result);
        }

        private static string GetMostCommonNumber(IEnumerable<string> numbers)
        {
            return numbers
                        .GroupBy(n => n)
                        .OrderByDescending(n => n.Count())
                        .Select(n => n.Key)
                        .First();
        }
    }
}