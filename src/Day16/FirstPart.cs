using Day16.Services;

namespace Day16;

public static class FirstPart
{
    public static double GetResult(string[] fileLines)
    {
        var bitsQueue = QueueService.GeneratePriorityQueue(fileLines);

        var version = TransmissionService.GetVersion(bitsQueue);
        
        return version;
    }
}