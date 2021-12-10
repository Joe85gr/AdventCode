using System;
using System.IO;

namespace Day4
{
    public static class Program
    {
        private const string FilePath = "Day4.txt";

        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);
            
            var firstPartResult = FirstPart.GetResult(fileLines);
            var secondPartResult = SecondPart.GetResult(fileLines);
            
            Console.WriteLine($"Day 4 - First Part result: {firstPartResult}");
            Console.WriteLine($"Day 4 - Second Part result: {secondPartResult}");
        }
    }
}