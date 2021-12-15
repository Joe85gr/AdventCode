namespace Day15.Services;

public static class CaveService
{
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