using System.Text;
using Day16.Domain;
using Day16.Models;

namespace Day16.Services;

public static class TransmissionService
{
    public static (double version, double valuesSum) GetVersion(PriorityQueue<char, int> queue, bool isSubPacket = false)
    {
        var values = 0d;
        var versions = 0d;
        
        while (queue.Count > 6)
        {
            versions += Converter.BitsToInt(QueueService.GetBits(queue, 3));
            var type = (TypeId)Converter.BitsToInt(QueueService.GetBits(queue, 3));

            if (type == TypeId.Literal)
            {
                var literal = CalculateLiteral(queue);
                values += literal;
            }
            else
            {
                var (subPacketsVersions, subPacketsValues) = ProcessOperator(queue, type);
                versions += subPacketsVersions;
                values += subPacketsValues;
            }
            
            if(isSubPacket) break;

        }

        return (versions, values);
    }

    private static (double version, double values) ProcessOperator(PriorityQueue<char, int> queue, TypeId type)
    {
        var versions = 0d;
        var lenghtTypeId = queue.Dequeue();
                
        var valuesList = new List<double>();

        if (lenghtTypeId == '0')
        {
            var totalLenght = Converter.BitsToInt(QueueService.GetBits(queue, 15));
            var subQueue = QueueService.CreateNewQueue(queue, totalLenght);
                    
            while (subQueue.Count > 6)
            {
                var (ver, val) = GetVersion(subQueue, true);
                versions += ver;
                valuesList.Add(val);
            }
        }
        else
        {
            var subPackets = Converter.BitsToInt(QueueService.GetBits(queue, 11));
                    
            for (var i = 0; i < subPackets; i++)
            {
                if (type == TypeId.Product) versions += 0;
                var (ver, val) = GetVersion(queue, true);
                versions += ver;
                valuesList.Add(val);
            }
        }
        
        var values = ProcessTypeIds(type, valuesList);

        return (versions, values);
    }
    
    private static double ProcessTypeIds(TypeId type, IReadOnlyList<double> values) => type switch
    {
        TypeId.Sum => values.Sum(),
        TypeId.Product => values.Count == 1 ? values[0] : values.Aggregate(1d, (curr, next) => curr * next),
        TypeId.Minimum => values.Min(),
        TypeId.Maximum => values.Max(),
        TypeId.GreaterThan => values.Count == 1 || values[0] > values[1] ? 1 : 0,
        TypeId.LessThan => values.Count == 1 || values[0] < values[1] ? 1 : 0,
        TypeId.EqualTo => values.Count == 1 || Math.Abs(values[0] - values[1]) == 0 ? 1 : 0,
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected typeId value: {type.ToString()}"),
    };
    
    private static double CalculateLiteral(PriorityQueue<char, int> queue)
    {
        var literalValueString = new StringBuilder();
        var isLastGroup = false;
        
        while (isLastGroup == false)
        {
            var firstBit = queue.Dequeue();
            if(firstBit == '0') isLastGroup = true;
            
            literalValueString.Append(QueueService.GetBits(queue, 4));
        }
        
        var literalValue = Converter.BitsToDouble(literalValueString);
        
        return literalValue;
    }
}