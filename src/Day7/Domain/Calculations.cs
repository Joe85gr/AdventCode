namespace Day7.Domain
{
    public static class Calculations
    {
        public static int CalculateTriangle(int steps)
        {
            var total = 0;
            
            for (var i = 1; i <= steps; i++)
                total += i;

            return total;
        }
    }
}