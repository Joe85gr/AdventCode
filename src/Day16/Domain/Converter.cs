using System.Text;

namespace Day16.Domain;

public static class Converter
{
    public static int BitsToInt(IEnumerable<char> bits)
    {
        return Convert.ToInt32(string.Join("", bits), 2);
    }
    public static double BitsToDouble(StringBuilder bits)  
    {  
        return double.Parse(Convert.ToInt64(bits.ToString(), 2).ToString());
    }  
    
    public static double BitsToDouble(IEnumerable<char> bits)  
    {  
        return double.Parse(Convert.ToInt64(string.Join("", bits), 2).ToString());
    }  
}