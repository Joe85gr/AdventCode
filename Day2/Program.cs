using System;
using System.IO;

namespace Day2
{
    internal static class Program
    {
        private const string FilePath = "Day2.txt";

        private static void Main()
        {
            var fileLines = File.ReadAllLines(FilePath);

            var horizontal = 0d;
            var depth = 0d;
            var aim = 0d;
            
            foreach (var line in fileLines)
            {
                var data = line.Split(' ');
                var instruction = data[0];
                var value = Convert.ToDouble(data[1]);

                switch (instruction)
                {
                    case "forward":
                        horizontal += value;
                        depth += aim * value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                }
            }
            
            Console.WriteLine(horizontal * depth);
        }
    }
}