namespace Day15.Services;

public static class RiskService
{
    public static double Dijkstra(Dictionary<(int x, int y), double> riskLevelMap,
        Dictionary<(int x, int y), double> distances, KeyValuePair<(int x, int y), double> start)
    {
        var visited = new HashSet<(int x, int y)>();
        var queue = new PriorityQueue<(int x, int y), double>();

        var (startCoordinate, startValue) = start;

        queue.Enqueue(startCoordinate, startValue);

        while (queue.Count > 0)
        {
            FindShotestPath(riskLevelMap, distances, visited, queue);
        }

        var totalRiskPath = distances.Last().Value;

        return totalRiskPath;
    }

    private static Dictionary<(int x, int y), double> GetNeighbours(IReadOnlyDictionary<(int x, int y), double> riskLevelMap,
        (int x, int y) start, IReadOnlySet<(int x, int y)> visited)
    {
        var end = riskLevelMap.Last().Key;

        var neighbours = new Dictionary<(int x, int y), double>();

        // Left
        if (start.x > 0 && visited.Contains((start.x - 1, start.y)) == false)
            neighbours.Add((start.x - 1, start.y), riskLevelMap[(start.x - 1, start.y)]);
        // Down
        if (start.y > 0 && visited.Contains((start.x, start.y - 1)) == false)
            neighbours.Add((start.x, start.y - 1), riskLevelMap[(start.x, start.y - 1)]);
        // Right
        if (start.x < end.x && visited.Contains((start.x + 1, start.y)) == false)
            neighbours.Add((start.x + 1, start.y), riskLevelMap[(start.x + 1, start.y)]);
        // Up
        if (start.y < end.y && visited.Contains((start.x, start.y + 1)) == false)
            neighbours.Add((start.x, start.y + 1), riskLevelMap[(start.x, start.y + 1)]);

        return neighbours;
    }

    private static void FindShotestPath(IReadOnlyDictionary<(int x, int y), double> riskLevelMap, IDictionary<(int x, int y), double> distances,
        HashSet<(int x, int y)> visited, PriorityQueue<(int x, int y), double> queue)
    {
        queue.TryDequeue(out var current, out var value);
        
        if(distances[current] > 0 && distances[current] < value) return;

        visited.Add(current);

        var neighbours = GetNeighbours(riskLevelMap, current, visited);
        
        foreach (var (neighbourCoordinates, neighbourDistance) in neighbours)
        {
            var newDistance = distances[current] + neighbourDistance;

            if (newDistance >= distances[neighbourCoordinates]) continue;

            distances[neighbourCoordinates] = newDistance;

            queue.Enqueue(neighbourCoordinates, newDistance);
        }
    }
}