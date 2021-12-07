using System.Collections.Generic;
using System.Linq;

namespace Day7.Services
{
    public class CrabService
    {
        public static IEnumerable<int> GetCrabs(IEnumerable<string> fileLines)
        {
            return fileLines.First()
                .Split(',')
                .Select(int.Parse);
        }
    }
}