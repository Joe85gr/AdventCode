using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2021.Day09
{
    public class SmokeBasinChallenge
    {
        private readonly int[,] _heightMap;
        private readonly int _width;
        private readonly int _height;

        public SmokeBasinChallenge(IReadOnlyList<string> inputData)
        {
            _width = inputData[0].Length;
            _height = inputData.Count;
            _heightMap = new int[_height, _width];

            for (var y = 0; y < inputData.Count; y++)
            {
                var line = inputData[y];
                var values = line.ToCharArray();

                for (var x = 0; x < values.Length; x++)
                {
                    _heightMap[y,x] = int.Parse(values[x].ToString());
                }
            }
        }

        public int Part1()
        {
            return GetCoordinatesOfLowPoints()
                .Aggregate(0, (total, coordinates) => total += _heightMap[coordinates.Y, coordinates.X] + 1);
        }

        private IEnumerable<(int Y, int X)> GetAdjacentHeightCoordinates(int y, int x)
        {
            if (y - 1 >= 0) yield return new(y - 1, x);
            if (x - 1 >= 0) yield return new(y, x - 1);
            if (x + 1 < _width) yield return new(y, x + 1);
            if (y + 1 < _height) yield return new(y + 1, x);
        }

        private IEnumerable<(int Y, int X)> GetCoordinatesOfLowPoints()
        {
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    var adjacentHeights = GetAdjacentHeightCoordinates(y, x);

                    if (adjacentHeights.All(adj => _heightMap[adj.Y, adj.X] > _heightMap[y, x])) yield return (y, x);
                }
            }
        }

        private void GetCoordinatesOfCloseNeighbours(int y, int x, HashSet<(int Y, int X)> neighbours)
        {
            var currentHeight = _heightMap[y, x];

            var neighbouringHeightCoordinates = GetAdjacentHeightCoordinates(y, x)
                .Where((coordinates) => neighbours.Any(n => n.X == coordinates.X && n.Y == coordinates.Y) == false)
                .Where((coordinates) => _heightMap[coordinates.Y, coordinates.X] < 9)
                .Where((coordinates) =>
                    (_heightMap[coordinates.Y, coordinates.X] == currentHeight + 1
                    || _heightMap[coordinates.Y, coordinates.X] == currentHeight - 1))
                .ToList();

            foreach (var neighbour in neighbouringHeightCoordinates)
            {
                neighbours.Add(neighbour);

                GetCoordinatesOfCloseNeighbours(neighbour.Y, neighbour.X, neighbours);
            }
        }

        public int Part2()
        {
            var lowPoints = GetCoordinatesOfLowPoints();

            var basinSizes = new List<int>();

            foreach (var lowPoint in lowPoints)
            {
                var basin = new HashSet<(int Y, int X)> { lowPoint };

                GetCoordinatesOfCloseNeighbours(lowPoint.Y, lowPoint.X, basin);

                basinSizes.Add(basin.Count);
            }

            return basinSizes
                .OrderByDescending(x => x)
                .Take(3)
                .Aggregate(1, (total, value) => total * value);
        }
    }
}
