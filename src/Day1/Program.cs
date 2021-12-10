using System;
using System.IO;

namespace Day1
{
    internal static class Program
    {
        private const string FilePath = "Day1.txt";

        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);
            
            var tot = SecondPart.GetResult(fileLines);
            
            Console.WriteLine($"Total: {tot}");
        }

    }
}