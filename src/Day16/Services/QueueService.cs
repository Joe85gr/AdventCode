using System.Text;
using Day16.Domain;

namespace Day16.Services;

public static class QueueService
{
    public static PriorityQueue<char, int> GeneratePriorityQueue(IEnumerable<string> fileLines)
    {
        var bits = GetBits(fileLines).ToList();
        
        var bitsQueue = new PriorityQueue<char, int>();

        for (var priority = 0; priority < bits.Count; priority++)
            bitsQueue.Enqueue(bits[priority], priority);

        return bitsQueue;
    }
    
    public static PriorityQueue<char, int> CreateNewQueue(PriorityQueue<char, int> queue, int elementsToTake)
    {
        var newQueue = new PriorityQueue<char, int>();

        for (var i = 0; i < elementsToTake; i++)
        {
            queue.TryDequeue(out var chr, out var priority);
            newQueue.Enqueue(chr, priority);
        }

        return newQueue;
    }
    
    public static string GetBits(PriorityQueue<char, int> queue, int bitCount)
    {
        var bitBuilder = new StringBuilder();
        
        for (var i = 0; i < bitCount; i++) bitBuilder.Append(queue.Dequeue());

        return bitBuilder.ToString();
    }
    
    private static IEnumerable<char> GetBits(IEnumerable<string> fileLines)
    {
        return fileLines
            .First()
            .Select(Map.HexToBit)
            .SelectMany(h => h)
            .ToArray();
    }
}