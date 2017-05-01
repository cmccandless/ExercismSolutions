using System.Collections.Generic;
using System.Linq;

public static class FoodChain
{
    private static string[][] words = new[] {
        new[]{"fly",string.Empty,string.Empty},
        new[]{"spider","It wriggled and jiggled and tickled inside her.",
            " that wriggled and jiggled and tickled inside her"},
        new[]{"bird","How absurd to swallow a bird!",string.Empty},
        new[]{"cat","Imagine that, to swallow a cat!",string.Empty},
        new[]{"dog","What a hog, to swallow a dog!",string.Empty},
        new[]{"goat","Just opened her throat and swallowed a goat!",string.Empty},
        new[]{"cow","I don't know how she swallowed a cow!",string.Empty},
        new[]{"horse","She's dead, of course!",string.Empty},
    };
    private static IEnumerable<int> Range(int stop, int start = 0, int inc = 1)
    {
        if (inc == 0) yield break;
        while ((inc > 0 && start < stop) || (inc < 0 && start > stop))
        {
            yield return start;
            start += inc;
        }
    }
    private static string Phrase(int i) => $"She swallowed the {words[i][0]} to catch the {words[i - 1][0]}{words[i - 1][2]}.";
    private static string GetVerse(int n)
    {
        n -= 1;
        var list = new List<string> { $"I know an old lady who swallowed a {words[n][0]}." };
        if (n > 0) list.Add(words[n][1]);
        if (n < 7)
        {
            list.AddRange(Range(0, n, -1).Select(Phrase));
            list.Add("I don't know why she swallowed the fly. Perhaps she'll die.");
        }
        return string.Join("\n", list);
    }
    public static string Verse(int n) => Verse(n, n);
    public static string Verse(int start, int stop) =>
        string.Join("\n\n", Range(stop + 1, start).Select(GetVerse));
}
