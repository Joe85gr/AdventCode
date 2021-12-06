using System;
using System.IO;

namespace Day5
{
    public static class Program
    {
        private const string FilePath = "Day5.txt";

        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);
            
            var firstPartResult = FirstPart.GetResult(fileLines);
            var secondPartResult = SecondPart.GetResult(fileLines);
            
            Console.WriteLine($"Day 5 - First Part result: {firstPartResult}");
            Console.WriteLine($"Day 5 - Second Part result: {secondPartResult}");
        }
    }
}