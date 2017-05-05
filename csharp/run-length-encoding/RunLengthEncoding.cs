using System.Linq;
using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    private static Regex rgxEnc = new Regex(@"(?<c>.)\k<1>*", RegexOptions.Compiled);
    public static string Encode(string input)
    {
        return string.Join(string.Empty,
            from Match match in rgxEnc.Matches(input)
            let value = match.Groups[0].Value
            let count = value.Length > 1 ? value.Length.ToString() : string.Empty
            select $"{count}{value[0]}");
    }
    private static Regex rgxDec = new Regex(@"(\d+)?([^\d])", RegexOptions.Compiled);
    public static string Decode(string input)
    {
        return string.Join(string.Empty,
            from Match match in rgxDec.Matches(input)
            let values = (from Group grp in match.Groups
                          select grp.Value).ToArray()
            let count = values[1].Length > 0 ? int.Parse(values[1]) : 1
            select new string(values[2][0], count));
    }
}
