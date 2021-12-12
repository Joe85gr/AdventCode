using System.Collections.Generic;
using Day11.Services;
using Xunit;

namespace Tests.Day11.Tests
{
    public class DumboOctopusesServiceTests
    {
        [Fact]
        public void StartStep_Returns_0_IfValueIs10()
        {
            var energyMap = new List<List<int>>
            {
                new() {10, 10, 10, 10}, new() {10, 10, 10, 10},
                new() {10, 10, 10, 10}, new() {10, 10, 10, 10}
            };
            
            var actual = OctopusService.StartStep(energyMap, new HashSet<(int x, int y)>());

            Assert.Equal(0, actual);
        }
        
        [Fact]
        public void StartStep_Returns_0_IfValueIsLessThan9()
        {
            var energyMap = new List<List<int>>
            {
                new() {10, 10, 10, 10}, new() {10, 1, 2, 10}, 
                new() {10, 3, 4, 10}, new() {10, 5, 6, 10}
            };
            
            var actual = OctopusService.StartStep(energyMap, new HashSet<(int x, int y)>());

            Assert.Equal(0, actual);
        }
        
        [Fact]
        public void StartStep_ReturnsCorrectCount_ForAll9Values()
        {
            var energyMap = new List<List<int>>
            {
                new() {10, 10, 10, 10}, new () {10, 9, 9, 10}, 
                new () {10, 9, 9, 10}, new () {10, 10, 10, 10}
            };
            
            var actual = OctopusService.StartStep(energyMap, new HashSet<(int x, int y)>());

            Assert.Equal(4, actual);
        }
    }
}