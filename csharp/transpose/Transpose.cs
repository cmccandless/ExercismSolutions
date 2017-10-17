using System.Linq;

public static class Transpose
{
    private static string TrimEndSingle(this string s) => s.EndsWith(" ") ? s.Substring(0, s.Length - 1) : s;

    public static string String(string input) => String(input.Split('\n')).TrimEnd();

    public static string String(string[] lines) => string.Join("\n", String(lines, lines.Max(s => s.Length)));

    private static string ColumnAsRow(this string[] lines, byte _, int c) =>
        new string(lines.Select(s => c < s.Length ? s[c] : ' ').ToArray());

    public static string[] String(string[] lines, int maxLen) => new byte[maxLen].Select(lines.ColumnAsRow).ToArray();
}
