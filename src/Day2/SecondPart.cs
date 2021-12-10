using System;
using System.Collections.Generic;

namespace Day2
{
    public static class SecondPart
    {
        public static double GetResult(IEnumerable<string> directions)
        {
            var horizontal = 0d;
            var depth = 0d;
            var aim = 0d;
            
            foreach (var direction in directions)
            {
                var data = direction.Split(' ');
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

            var result = horizontal * depth;

            return result;
        }
    }
}