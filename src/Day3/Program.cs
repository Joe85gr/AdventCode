using System;
using System.IO;

namespace Day3
{
    internal static class Program
    {
        private const string FilePath = "Day3.txt";

        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);
            var watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            var firstPartResult = FirstPart.GetResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Day 3 - First Part result: {firstPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
            
            watch.Start();
            var secondPartResult = SecondPart.GetResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Day 3 - Second Part result: {secondPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
        }
    }
}