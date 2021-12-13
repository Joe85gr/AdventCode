using System;
using System.IO;

namespace Day13
{
    public static class Program
    {
        private const string FilePath = "Day13.txt";

        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            var firstPartResult = FirstPart.GetResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Day 13 - First Part result: {firstPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
            
            watch.Start();
            SecondPart.PrintResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
        }
    }
}