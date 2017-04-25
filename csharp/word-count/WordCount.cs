using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Phrase
{
    private static Regex rgxPunctuation =
        new Regex(@"[&@$%^.:;!?]|(?:'(?:\W|$))|(?:(?:\W|^)')", RegexOptions.Compiled);

    private static string[] FilterSplit(string phrase) =>
        rgxPunctuation.Replace(phrase, " ").ToLower()
        .Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

    public static Dictionary<string, int> WordCount(string phrase) =>
        FilterSplit(phrase).GroupBy(t => t).ToDictionary(grp => grp.Key, grp => grp.Count());
}
