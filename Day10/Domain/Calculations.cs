using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10.Domain
{
    public static class Calculations
    {
        public static double GetTotalAutoCompleteScore(IEnumerable<char> corruptedChars)
        {
            return corruptedChars
                .Aggregate(0d, (current, corruptedChar) => current * 5 + AutoCompletePoints(corruptedChar));
        }
        
        public static double GetTotalErrorScore(IEnumerable<char> corruptedChars)
        {
            return corruptedChars.Sum(ErrorPoints);
        }
        
        private static double ErrorPoints(char character) => character switch
        {
            '>' => 25137,
            ')' =>  3,
            ']' =>  57,
            '}' =>  1197,
            _ => 0
        };

        private static double AutoCompletePoints(char character) => character switch
        {
            '(' =>  1,
            '[' =>  2,
            '{' =>  3,
            '<' => 4,
            _ => 0
        };
    }
}