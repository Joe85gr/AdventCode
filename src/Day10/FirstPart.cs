using System.Collections.Generic;
using System.Linq;
using Day10.Domain;
using Day10.Services;

namespace Day10
{
    public class FirstPart
    {
        private readonly RouteService _routeService  = new();
        
        public double GetResult(IEnumerable<string> corruptedChunks)
        {
            var corruptedCharacters = corruptedChunks
                .Select(x => _routeService.GetFirstCorruptedChar(x))
                .ToList();

            var totalScore = Calculations.GetTotalErrorScore(corruptedCharacters);
            
            return totalScore;
        }
    }
}