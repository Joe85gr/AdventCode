using System;
using System.Collections.Generic;
using System.Linq;
using Day6.Models;

namespace Day6
{
    public static class SecondPart
    {
        private const int Days = 256;
        public static double GetResult(string[] fileLines)
        {
            var fishes = fileLines.First()
                .Split(',')
                .Select(l => Convert.ToInt32(l));

            var result = fishes
                .Sum(fish => Count(fish, 0));

            return result;
        }

        public static double Count(int fish, int startDay)
        {
            var count = 0d;
            
            var reproductionDays = Days - startDay;
            var newBornFishes = (reproductionDays - fish - 1) / 7;
            if(reproductionDays > 0) newBornFishes++;
            count++;

            for (var j = 0; j < newBornFishes; j++)
            {
                var newStartDay = fish + startDay + 1 + (7 * j);
                if(startDay > Days) continue;
                count += Count(8, newStartDay);
            }

            return count;
        }
    }
}