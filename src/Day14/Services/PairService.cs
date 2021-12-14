namespace Day14.Services;

public static class PairService
{
    public static Dictionary<string, char> GetPairInsertions(IEnumerable<string> fileLines)
    {
        var pairs = fileLines
            .Skip(2)
            .Select(PairRule)
            .ToDictionary(p => p.Key, p => p.Value[0]);

        return pairs;
    }

    public static Dictionary<string, double> GetPairsToProcess(string polymerTemplate)
    {
        var pairsToProcess = new Dictionary<string, double>();

        for (var i = 0; i < polymerTemplate.Length - 1; i++)
        {
            var pair = polymerTemplate.Substring(i, 2);
            
            if (pairsToProcess.ContainsKey(pair)) pairsToProcess[pair] += 1;
            else pairsToProcess.Add(pair, 1);
        }
            
        return pairsToProcess;
    }
    
    public static Dictionary<string, double> ProcessPairs(Dictionary<string, double> pairsToProcess,
        Dictionary<char, double> lettersCount, Dictionary<string, char> pairInsertions)
    {
        var newPairsToProcess = new Dictionary<string, double>(pairsToProcess);
        
        foreach (var (pair, letter) in pairInsertions)
        {
            if (pairsToProcess.ContainsKey(pair) == false) continue;

            var letterCountOffset = pairsToProcess[pair];
            AddNewLettersAndPairs(pair, letter, newPairsToProcess, letterCountOffset);

            if (lettersCount.ContainsKey(letter)) lettersCount[letter] += pairsToProcess[pair];
            else lettersCount.Add(letter, 1);
        }
        
        return newPairsToProcess;
    }
    
    private static void AddNewLettersAndPairs(string pair, char letter, 
        IDictionary<string, double> newPairsToProcess, double letterCountOffset)
    {
        newPairsToProcess[pair] -= letterCountOffset;
        
        var leftPair = string.Concat(pair[0], letter);
        var rightPair = string.Concat(letter, pair[1]);

        if (newPairsToProcess.ContainsKey(leftPair)) newPairsToProcess[leftPair] += letterCountOffset;
        else newPairsToProcess.Add(leftPair, letterCountOffset);
        
        if (newPairsToProcess.ContainsKey(rightPair)) newPairsToProcess[rightPair] += letterCountOffset;
        else newPairsToProcess.Add(rightPair, letterCountOffset);
    }

    private static KeyValuePair<string, string> PairRule(string line)
    {
        var splitRule = line.Split(" -> ");

        return new KeyValuePair<string, string>(splitRule[0], splitRule[1]);
    }
}