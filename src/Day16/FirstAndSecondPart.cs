using Day16.Services;

namespace Day16;

public static class FirstAndSecondPart
{
    public static (double version, double value) GetResult(IEnumerable<string> fileLines)
    {
        var bitsQueue = QueueService.GeneratePriorityQueue(fileLines);

        var (versions, values) = TransmissionService.GetVersion(bitsQueue);
        
        return (versions, values);
    }
}