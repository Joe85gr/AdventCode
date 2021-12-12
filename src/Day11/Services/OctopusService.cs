using System.Collections.Generic;

namespace Day11.Services
{
    public static class OctopusService
    {
        public static double StartStep(List<List<int>> energyMap, HashSet<(int x, int y)> flashed)
        {
            var flashes = 0d;
            
            for (var y = 1; y < energyMap.Count - 1; y++)
            {
                for (var x = 1; x < energyMap[0].Count - 1; x++)
                {
                    if(energyMap[y][x] == 10) continue;
                    if(energyMap[y][x] == 9) flashes+=LightHasFlashed(energyMap, x, y, flashed);
                    if(flashed.Contains((x, y)) == false) energyMap[y][x]++;
                }
            }

            return flashes;
        }

        private static double IncreaseAdjacent(List<List<int>> energyMap, int x1, int y1, HashSet<(int x, int y)> flashed)
        {
            var count = 0d;

            var adjacentCoordinates = new List<(int x, int y)>
            {
                (x1 - 1, y1 - 1), (x1, y1 - 1), (x1 + 1, y1 - 1),
                (x1 - 1, y1),                   (x1 + 1, y1),
                (x1 - 1, y1 + 1), (x1, y1 + 1), (x1 + 1, y1 + 1)
            };

            foreach (var (x2, y2) in adjacentCoordinates)
            {
                if(flashed.Contains((x2, y2))) continue;
                if(energyMap[y2][x2] == 10) continue;
                if(energyMap[y2][x2] == 9) count+=LightHasFlashed(energyMap, x2, y2, flashed);
                else energyMap[y2][x2]++;
            }

            return count;
        }

        private static double LightHasFlashed(List<List<int>> energyMap, int x, int y, HashSet<(int x, int y)> flashed)
        {
            var flashes = 0d;

            flashed.Add((x, y));
            
            energyMap[y][x] = 0;
            flashes++;
            flashes+=IncreaseAdjacent(energyMap, x, y, flashed);

            return flashes;
        }
    }
}