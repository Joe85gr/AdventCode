using System.Text;
using Day16.Domain;

namespace Day16.Services;

public static class TransmissionService
{
    public static double GetVersion(PriorityQueue<char, int> queue)
    {
        var version = 0d;
        while (queue.Count > 6)
        {
            version += Converter.BitsToInt(GetBitsFromQueue(queue, 3));
            var type = Converter.BitsToInt(GetBitsFromQueue(queue, 3));

            if (type == 4)
            {
                var literal = CalculateLiteral(queue);
            }
            else
            {
                var lenghtTypeId = queue.Dequeue();

                if (lenghtTypeId == '0')
                {
                    var totalLenght = Converter.BitsToInt(GetBitsFromQueue(queue, 15));
                    var subQueue = CreateNewQueue(queue, totalLenght);
                    version += GetVersion(subQueue);
                }
                else
                {
                    var subPackets = Converter.BitsToInt(GetBitsFromQueue(queue, 11));
                }
            }

        }

        return version;
    }
    private static string GetBitsFromQueue(PriorityQueue<char, int> queue, int bitCount)
    {
        var bitBuilder = new StringBuilder();
        for (var i = 0; i < bitCount; i++)
        {
            bitBuilder.Append(queue.Dequeue());
        }

        return bitBuilder.ToString();
    }

    private static PriorityQueue<char, int> CreateNewQueue(PriorityQueue<char, int> queue, int elementsToTake)
    {
        var newQueue = new PriorityQueue<char, int>();

        for (var i = 0; i < elementsToTake; i++)
        {
            queue.TryDequeue(out var chr, out var priority);
            newQueue.Enqueue(chr, priority);
        }

        return newQueue;
    }

    private static double CalculateLiteral(PriorityQueue<char, int> queue)
    {
        var literalValueString = new StringBuilder();
        var isLastGroup = false;
        while (isLastGroup == false)
        {
            var firstBit = queue.Dequeue();
            if(firstBit == '0') isLastGroup = true;
            
            literalValueString.Append(GetBitsFromQueue(queue, 4));
        }
        
        var literalValue = Converter.BitsToDouble(literalValueString);
        
        return literalValue;
    }
}