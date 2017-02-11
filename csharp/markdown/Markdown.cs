using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Markdown
{
	private static string Wrap(string text, string tag) { return string.Format("<{0}>{1}</{0}>", tag, text); }

	private static bool IsTag(string text, string tag) { return text.StartsWith(string.Format("<{0}>", tag)); }

	private static string Parse(string markdown, string delimiter, string tag)
	{
		var pattern = string.Format("{0}(.+){0}", delimiter);
		var replacement = Wrap("$1", tag);
		return Regex.Replace(markdown, pattern, replacement);
	}

	private static string Parse__(string markdown) { return Parse(markdown, "__", "strong"); }

	private static string Parse_(string markdown) { return Parse(markdown, "_", "em"); }

	private static string ParseText(string markdown, bool list)
	{
		var parsedText = Parse_(Parse__(markdown));
		return list ? parsedText : Wrap(parsedText, "p");
	}

	private static string ParseHeader(string markdown, bool list, out bool inListAfter)
	{
		inListAfter = list;
		var count = markdown.TakeWhile(m => m.Equals('#')).Count();
		if (count == 0) return null;

		var headerTag = "h" + count;
		var headerHtml = Wrap(markdown.Substring(count + 1), headerTag);

		inListAfter = false;
		if (list) headerHtml = "</ul>" + headerHtml;
		return headerHtml;
	}

	private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
	{
		if (markdown.StartsWith("*"))
		{
			var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");
			inListAfter = true;
			if (!list) innerHtml = "<ul>" + innerHtml;
			return innerHtml;
		}

		inListAfter = list;
		return null;
	}

	private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
	{
		inListAfter = false;
		var result = ParseText(markdown, list);
		if (list) result = "</ul>" + result;
		return result;
	}

	private static string ParseLine(string markdown, bool list, out bool inListAfter)
	{
		var result = ParseHeader(markdown, list, out inListAfter) ?? 
			ParseLineItem(markdown, list, out inListAfter) ??
			ParseParagraph(markdown, list, out inListAfter);
		if (result == null) throw new ArgumentException("Invalid markdown");
		return result;
	}

	public static string Parse(string markdown)
	{
		var list = false;
		var result = string.Join(string.Empty, markdown.Split('\n').Select(line => ParseLine(line, list, out list)));
		if (list) result += "</ul>";
		return result;
	}
}