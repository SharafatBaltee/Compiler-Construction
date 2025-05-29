using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "if (a && b || !c)";
        string pattern = @"&&|\|\||!";

        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            Console.WriteLine($"Found logical operator: {match.Value}");
        }
    }
}