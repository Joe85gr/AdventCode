using System.Collections.Generic;
using System.Linq;

namespace Day10.Services
{
    public class RouteService
    {
        private readonly Dictionary<char, char> _matchingParenthesis = new()
        {
            {'>', '<'},{')', '('},
            {']', '['},{'}', '{'}
        };
        public char GetFirstCorruptedChar(string errorChunk, List<char> bitsSoFar = null)
        {
            bitsSoFar ??= new List<char>();
            
            var errorBits = errorChunk.ToCharArray();

            var currentChar = '\0';

            for (var i = 0; i < errorBits.Length; i++)
            {
                currentChar = errorBits[i];
                
                if(_matchingParenthesis.ContainsValue(currentChar)) bitsSoFar.Add(currentChar);
                else if (bitsSoFar.Last() == _matchingParenthesis[currentChar])
                {
                    bitsSoFar.RemoveAt(bitsSoFar.Count - 1);
                    if (i == errorBits.Length - 1) currentChar = '\0';
                }
                else break;
            }
            
            return currentChar;
        }
    }
}