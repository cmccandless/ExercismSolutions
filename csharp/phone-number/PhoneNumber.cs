using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    private static Regex rgx = new Regex(@"^1?([2-9]\d{2}[2-9]\d{6})$");

    public static string Clean(string number)
    {
        number = string.Join("", number.Where(char.IsLetterOrDigit));
        var match = rgx.Match(number);
        if (string.IsNullOrEmpty(match.Value)) throw new ArgumentException();
        return string.Join("", match.Groups.Skip(1).Select(g => g.Value));
    }
}
