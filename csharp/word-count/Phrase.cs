using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Phrase
{
	private static Regex rgxPunctuation =
		new Regex(@"[&@$%^.:;!?]|(?:'(?:\W|$))|(?:(?:\W|^)')", RegexOptions.Compiled);
	internal static Dictionary<string,int> WordCount(string phrase)
	{
		return (from word in rgxPunctuation.Replace(phrase, " ")
					.ToLower()
					.Split(new[]{" ",","}, StringSplitOptions.RemoveEmptyEntries)
				group word by word)
				.ToDictionary(grp => grp.Key, grp => grp.Count());
	}
}
