using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public static class FirstPart
    {
        private const int Days = 80;
        public static double GetResult(IEnumerable<string> fileLines)
        {
            var fishes = fileLines.First()
                .Split(',')
                .Select(l => new[]  { Convert.ToInt32(l), 0})
                .ToList();

            var count = 0d;

            count += RecursiveCount(fishes);
            
            var result = count;

            return result;
        }

        private static double RecursiveCount(List<int[]> fishes)
        {
            var count = 0d;
            
            foreach (var t in fishes)
            {
                var reproductionDays = Days - t[1];
                var newBornFishes = (reproductionDays - t[0] - 1) / 7;
                if(reproductionDays > 6) newBornFishes++;
                count++;

                var children = new List<int[]>();
                
                for (var j = 0; j < newBornFishes; j++)
                {
                    var startDay = t[1] + t[0] + 1 + (7 * j);
                    if(startDay > Days) continue;
                    children.Add(new[] { 8, startDay});
                }

                if (children.Any()) count+=RecursiveCount(children);
            }

            return count;
        }
    }
}