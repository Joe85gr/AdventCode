using System.Text;

namespace Day16.Domain;

public static class Converter
{
    public static string HexToBit(char digit) => digit switch
    {
        '0' => "0000",
        '1' => "0001", 
        '2' => "0010", 
        '3' => "0011", 
        '4' => "0100", 
        '5' => "0101", 
        '6' => "0110", 
        '7' => "0111", 
        '8' => "1000", 
        '9' => "1001", 
        'A' => "1010",
        'B' => "1011",
        'C' => "1100",
        'D' => "1101",
        'E' => "1110",
        'F' => "1111",
        _ => throw new ArgumentOutOfRangeException(nameof(digit), $"Not expected digit value: {digit}"),
    };

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