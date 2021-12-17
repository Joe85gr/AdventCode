using Day16.Services;

namespace Day16;

public static class FirstPart
{
    public static (double version, double value) GetResult(IEnumerable<string> fileLines)
    {
        var bitsQueue = QueueService.GeneratePriorityQueue(fileLines);

        var (version, value) = TransmissionService.GetVersion(bitsQueue);
        
        return (version, value);
    }
}