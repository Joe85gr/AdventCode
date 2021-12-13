using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day13.Models
{
    public class PageService
    {
        private static void PrintPage(List<(int X, int Y)> coordinates)
        {
            var xMax = coordinates.Max(c => c.X) + 1;
            var yMax = coordinates.Max(c => c.Y) + 1;

            Console.WriteLine("-----------------------");

            for (var y = 0; y < yMax; y++)
            {
                var builder = new StringBuilder();
                
                for (var x = 0; x < xMax; x++)
                {
                    if (coordinates.Contains((x, y))) builder.Append("# ");
                    else builder.Append(". ");
                }
                
                Console.WriteLine(builder);
            }   
            
            Console.WriteLine("-----------------------");
        }
    }
}