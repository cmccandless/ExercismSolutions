using System.Linq;
using System.Text.RegularExpressions;

public static class PigLatin
{
    private static readonly string consonents = $"s?qu|sch|[st]hr?|[src]h|y[^t]|x[^r]|[^aeiou]";

    private static readonly string pattern = $@"^({consonents})?((yt?|xr|[aeiou])\w*)$";

    private static readonly Regex rgxWord = new Regex(pattern, RegexOptions.Compiled);

    public static string Translate(string phrase) => string.Join(" ", phrase.Split(' ').Select(TranslateWord));

    private static string TranslateWord(string word) => rgxWord.Replace(word, "$2$1ay");
}
