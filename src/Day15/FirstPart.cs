using Day15.Services;

namespace Day15;

public static class FirstPart
{
    public static double GetResult(string[] fileLines)
    {
        var riskLevelMap = CaveService.GetRiskLevels(fileLines);
        var start = riskLevelMap.First();
        var distances = riskLevelMap
            .Select(r => r.Key)
            .ToDictionary(r => r, _ => double.PositiveInfinity);

        distances[start.Key] = 0;

        var totalRiskPath = RiskService.Dijkstra(riskLevelMap, distances, start);
        
        return totalRiskPath;
    }
}

