using Day14.Services;

namespace Day14;

public static class FirstAndSecondPart
{
    public static double GetResult(string[] fileLines, int steps)
    {
        var polymerTemplate = fileLines.First();
    
        var lettersCount = LetterService.GetCurrentLetters(polymerTemplate);
        var pairsToProcess = PairService.GetPairsToProcess(polymerTemplate);
        var pairInsertions = PairService.GetPairInsertions(fileLines);
        
        for (var i = 0; i < steps; i++)
        {
            pairsToProcess = PairService.ProcessPairs(pairsToProcess, lettersCount, pairInsertions);
        }
    
        var mostCommon = lettersCount.Max(l => l.Value);
        var leastCommon = lettersCount.Min(l => l.Value);
    
        var result = mostCommon - leastCommon;
            
        return result;
    }
}