using System;
using System.IO;

namespace Day7
{
    public static class Program
    {
        private const string FilePath = "Day7.txt";

        private static void Main()
        {
            var watch = new System.Diagnostics.Stopwatch();
            
            var fileLines = File.ReadAllLines(FilePath);
            
            watch.Start();
            var firstPartResult = FirstPart.GetResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Day 7 - First Part result: {firstPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
            
            watch.Start();
            var secondPartResult = SecondPart.GetResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Day 7 - Second Part result: {secondPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
            
        }
    }
}