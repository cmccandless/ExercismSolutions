using System;
using System.Linq;

static class Acronym
{
	public static string Abbreviate(string phrase)
	{
		return string.Concat(from word in (phrase ?? string.Empty).Split(':').First()
								.Split(" -".ToArray(), StringSplitOptions.RemoveEmptyEntries)
							 from ch in new[] {word[0]}.Concat(word.Skip(1).Where(c=>char.IsUpper(c)))
							 select ch
							 ).ToUpper();
	}
}
