using System.Collections.Generic;
using System.Linq;
using Day10.Domain;
using Day10.Services;

namespace Day10
{
    public class SecondPart
    {
        private readonly RouteService _routeService = new();

        private readonly char[] _validChars = {'(', '[', '{', '<'};
        
        public double GetResult(IEnumerable<string> corruptedChunks)
        {
            var incompleteLines = FindIncompleteLines(corruptedChunks);
            
            var scores = incompleteLines
                .Select(Calculations.GetTotalAutoCompleteScore)
                .OrderByDescending(x => x)
                .ToList();

            var result = scores[scores.Count / 2];
            
            return result;
        }

        private IEnumerable<List<char>> FindIncompleteLines(IEnumerable<string> corruptedChunks)
        {
            var incompleteLines = new List<List<char>>();
            
            foreach (var corruptedChunk in corruptedChunks)
            {
                var bitsSoFar = new List<char>();
                var corruptedChar = _routeService.GetFirstCorruptedChar(corruptedChunk, bitsSoFar);

                if (_validChars.Contains(corruptedChar) || corruptedChar == '\0') 
                    incompleteLines.Add(ReverseArray(bitsSoFar));
            }

            return incompleteLines;
        }
        
        private static List<char> ReverseArray(IReadOnlyList<char> chars)
        {
            var reversedArray = new List<char>();

            for (var i = chars.Count - 1; i >= 0; i--)
            {
                reversedArray.Add(chars[i]);
            }

            return reversedArray;
        }
    }
}