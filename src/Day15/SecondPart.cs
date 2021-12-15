using Day15.Services;

namespace Day15;

public static class SecondPart
{
    public static double GetResult(string[] fileLines)
    {
        var riskLevelMap = CaveService.GetRiskLevelsPart2(fileLines);
        var start = riskLevelMap.First();
        var distances = GenerateDistances(riskLevelMap, start.Key);

        var totalRiskPath = RiskService.Dijkstra(riskLevelMap, distances, start);
        
        return totalRiskPath;
    }

    private static Dictionary<(int x, int y), double> GenerateDistances(Dictionary<(int x, int y), double> riskLevelMap, 
        (int x, int y) start)
    {
        var distances = riskLevelMap
            .Select(r => r.Key)
            .ToDictionary(r => r, _ => double.PositiveInfinity);

        distances[start] = 0;

        return distances;
    }
}

