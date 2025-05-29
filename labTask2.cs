using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "if (a == b && c != d && e > f && g < h && i >= j && k <= l)";
        string pattern = @"==|!=|>=|<=|>|<";

        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            Console.WriteLine($"Found relational operator: {match.Value}");
        }
    }
}
