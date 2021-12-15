namespace Day15.Services;

public static class CaveService
{
    public static Dictionary<(int x, int y), double> GetRiskLevelsPart2(string[] fileLines)
    {
        var input = GetRiskLevels(fileLines);

        var size = fileLines.Length;

        var riskLevelMap = Enumerable
            .Range(0, 5)
            .SelectMany(col =>Enumerable.Range(0, 5).SelectMany(row =>
                input.Select(l =>
                {
                    var ((x, y), value) = l;
                    (int x, int y) key = (x + size * col, y + size * row);
                    var newValue = (value + col + row - 1) % 9 + 1;
                    return (key, value: newValue);
                })))
            .ToDictionary(d => d.key, d => d.value );
        

        return riskLevelMap;
    }
    
    public static int AddValue(int value, int adding)
    {
        var newValue = value + adding;
        if (newValue > 9) newValue = newValue - 9;
        return newValue;
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