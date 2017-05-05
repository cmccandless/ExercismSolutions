using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Markdown
{
    private static string Wrap(this string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string Parse(this string markdown, string delimiter, string tag) =>
        Regex.Replace(markdown, $"{delimiter}(.+){delimiter}", "$1".Wrap(tag));

    private static string Parse__(this string markdown) => Parse(markdown, "__", "strong");

    private static string Parse_(this string markdown) => Parse(markdown, "_", "em");

    private static string ParseText(this string markdown, bool list)
    {
        var parsedText = markdown.Parse__().Parse_();
        return list ? parsedText : parsedText.Wrap("p");
    }

    private static string ParseHeader(this string markdown, bool list, out bool inListAfter)
    {
        inListAfter = list;
        var count = markdown.TakeWhile(m => m.Equals('#')).Count();
        if (count == 0) return null;

        var headerTag = $"h{count}";
        var headerHtml = markdown.Substring(count + 1).Wrap(headerTag);

        inListAfter = false;
        return list ? $"</ul>{headerHtml}" : headerHtml;
    }

    private static string ParseLineItem(this string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            inListAfter = true;
            var innerHtml = markdown.Substring(2).ParseText(true).Wrap("li");
            return list ? innerHtml : $"<ul>{innerHtml}";
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(this string markdown, bool list, out bool inListAfter)
    {
        inListAfter = false;
        var result = markdown.ParseText(list);
        return list ? $"</ul>{result}" : result;
    }

    private static string ParseLine(this string markdown, bool list, out bool inListAfter)
    {
        var result = markdown.ParseHeader(list, out inListAfter) ??
            markdown.ParseLineItem(list, out inListAfter) ??
            markdown.ParseParagraph(list, out inListAfter);
        if (result == null) throw new ArgumentException("Invalid markdown");
        return result;
    }

    public static string Parse(string markdown)
    {
        var list = false;
        var result = string.Join(string.Empty, markdown.Split('\n').Select(line => line.ParseLine(list, out list)));
        return list ? $"{result}</ul>" : result;
    }
}