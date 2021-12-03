using System;
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

            var firstPartResult = FirstPart.GetResult(fileLines);
            var secondPartResult = SecondPart.GetResult(fileLines);
            
            Console.WriteLine($"Day 3 - First Part Result: {firstPartResult}");
            Console.WriteLine($"Day 3 - Second Part Result: {secondPartResult}");
        }
    }
}