using System;
using System.Text;

namespace Day3.Domain
{
    public static class CustomConvert
    {
        public static int BitsToInt(StringBuilder bits) => Convert.ToInt32(bits.ToString(), 2);
        public static int BitsToInt(string bits) => Convert.ToInt32(bits, 2);
    }
}