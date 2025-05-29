using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] testCases = { "12.34", "0.123", "123.45", "1234.5", ".456", "123456", "123.4567", "1234567" };
        Regex regex = new Regex(@"^\d{0,5}\.\d{1,5}$|^\d{1,6}$");

        foreach (string num in testCases)
        {
            if (regex.IsMatch(num))
            {
                Console.WriteLine($"Valid: {num}");
            }
            else
            {
                Console.WriteLine($"Invalid: {num}");
            }
        }
    }
}
