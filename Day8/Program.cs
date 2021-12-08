using System;
using System.IO;

namespace Day8
{
    public static class Program
    {
        private const string FilePath = "Tests.txt";
        
        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            var firstPartResult = FirstPart.GetResult(fileLines);
            watch.Stop();
            Console.WriteLine($"Day 8 - First Part result: {firstPartResult}");
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
            //
            // watch.Start();
            // var secondPartResult = SecondPart.GetResult(fileLines);
            // watch.Stop();
            // Console.WriteLine($"Day 8 - Second Part result: {secondPartResult}");
            // Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
        }
    }
}