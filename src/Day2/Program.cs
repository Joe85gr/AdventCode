using System;
using System.IO;

namespace Day2
{
    internal static class Program
    {
        private const string FilePath = "Day2.txt";

        private static void Main()
        {
            var watch = new System.Diagnostics.Stopwatch();
            var directions = File.ReadAllLines(FilePath);
            
            watch.Start();
            var secondPartResult = SecondPart.GetResult(directions);
            watch.Stop();
            Console.WriteLine($"Day 7 - Second Part result: {secondPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
            
        }
    }
}