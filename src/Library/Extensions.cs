using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public static class Extensions
    {
        public static void Test(this Dictionary<(int x , int y), int> dictionary)
        {
            //dictionary = dictionary.OrderBy(d => d.Value).ToDictionary();
        }
    }
}