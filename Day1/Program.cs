using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Day1
{
    internal static class Program
    {
        private const string FilePath = "Day1.txt";

        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);
            var numbers = fileLines.Select(x => Convert.ToInt32(x)).ToList();
            
            var tot = GetCount(numbers);
            
            Console.WriteLine($"Total: {tot}");
        }
        private static int GetCount(List<int> numbers)
        {
            var count = 0;
            
            var previous = numbers[0] + numbers[1] + numbers[2];

            var reminder = numbers.Count % 3;
            
            for (var i = 1; i < numbers.Count - reminder; i++)
            {
                var current = numbers[i] + numbers[i + 1] + numbers[i + 2];
                
                if (current > previous) count++;

                previous = current;
            }

            return count;
        }
    }
}