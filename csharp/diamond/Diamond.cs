using System.Collections.Generic;
using System.Linq;

public class Diamond
{
    private static string Fill(char s, int left, int right) =>
        string.Join("", new[] { "".PadLeft(left), s.ToString(), "".PadRight(right) });

    private static IEnumerable<T> Mirror<T>(IEnumerable<T> col) =>
        col.Concat(col.Reverse().Skip(1));

    private static string Line(char c, char max) =>
        string.Join("", Mirror(Fill(c, max - c, c - 'A')));

    private static IEnumerable<char> CharRange(char stop, char start = 'A') =>
        new int[stop - start + 1].Select((_, c) => (char)(c + 'A'));

    public static string Make(char ch) =>
        string.Join("\n", Mirror(CharRange(ch).Select(c => Line(c, ch))));
}
