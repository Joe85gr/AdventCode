using System;
using System.IO;

namespace Day12
{
    public static class Program
    {
        private const string FilePath = "Day12.txt";

        private static readonly FirstPart FirstPart = new();
        private static readonly SecondPart SecondPart = new();
        
        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            var firstPartResult = FirstPart.GetResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Day 12 - First Part result: {firstPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
            
            watch.Start();
            var secondPartResult = SecondPart.GetResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Day 12 - Second Part result: {secondPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
        }
    }
}