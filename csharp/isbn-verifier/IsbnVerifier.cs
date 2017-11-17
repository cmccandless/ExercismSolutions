using System;
using System.Collections.Generic;
using System.Linq;

public static class IsbnVerifier
{
    private static int ParseDigit(char ch, int i)
    {
        if (i == 1 && ch == 'X') return 10;
        return int.Parse(ch.ToString());
    }
    public static bool IsValid(string number)
    {
        var clean = number.Replace("-", "");
        int parseDigit(int i)
        {
            if (i == 9 && clean[i] == 'X') return 10;
            return (10 - i) * int.Parse(clean[i].ToString());
        }
        try
        {
            return clean.Length == 10 &&
                   Enumerable.Range(0, 10).Sum(parseDigit) % 11 == 0;
        }
        catch (FormatException ex)
        {
            return false;
        }
    }
}
