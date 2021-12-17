using Day16.Domain;

namespace Day16.Services;

public static class QueueService
{
    public static PriorityQueue<char, int> GeneratePriorityQueue(IEnumerable<string> fileLines)
    {
        var bits = GetBits(fileLines);
        
        var bitsQueue = new PriorityQueue<char, int>();
        var priority = 1;
        foreach (var bit in bits)
        {
            bitsQueue.Enqueue(bit, priority);
            priority++;
        }

        return bitsQueue;
    }
    
    private static char[] GetBits(IEnumerable<string> fileLines)
    {
        return fileLines
            .First()
            .Select(Converter.HexToBit)
            .SelectMany(h => h)
            .ToArray();
    }
}