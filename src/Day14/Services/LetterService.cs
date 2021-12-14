namespace Day14.Services;

public static class LetterService
{
    public static Dictionary<char, double> GetCurrentLetters(string polymerTemplate)
    {
        var lettersCount = new Dictionary<char, double>();
        
        foreach (var letter in polymerTemplate)
        {
            if (lettersCount.ContainsKey(letter)) lettersCount[letter]++;
            else lettersCount.Add(letter, 1);
        }
        
        return lettersCount;
    }
}