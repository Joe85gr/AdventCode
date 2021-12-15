namespace Day15.Services;

public static class CaveService
{
    public static Dictionary<(int x, int y), double> GetRiskLevelsPart2(string[] fileLines)
    {
        var input = GetRiskLevels(fileLines);

        var size = fileLines.Length;

        var riskLevelMap = Enumerable
            .Range(0, 5)
            .SelectMany(col =>Enumerable.Range(0, 5)
                .SelectMany(row =>
                input.Select(l => AddValue(l, size, col, row))))
            .ToDictionary(d => d.key, d => d.value );
        

        return riskLevelMap;
    }

    private static ((int x, int y) key, double value) AddValue(KeyValuePair<(int x, int y), double> riskValue, 
        double size, int col, int row)
    {
        var ((x, y), value) = riskValue;
        var newKey = (Convert.ToInt32(x + size * col), Convert.ToInt32(y + size * row));
        var newValue = (value + col + row - 1) % 9 + 1;
        
        var keyPair = (newKey, newValue);

        return keyPair;
    }
    
    public static Dictionary<(int x, int y), double> GetRiskLevels(string[] fileLines)
    {
        var riskLevelMap = new Dictionary<(int x, int y), double>();
        
        for (var y = 0; y < fileLines.Length; y++)
        {
            for (var x = 0; x < fileLines[0].Length; x++)
            {
                riskLevelMap.Add((x,y), int.Parse(fileLines[y][x].ToString()));
            }
        }

        return riskLevelMap;
    }
}