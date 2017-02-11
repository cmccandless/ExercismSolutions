using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FoodChain
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
	public static string Verse(int n)
	{
		n -= 1;
		var list = new List<string> { string.Format("I know an old lady who swallowed a {0}.", words[n][0]) };
		if (n > 0) list.Add(words[n][1]);
		if (n < 7)
		{
			for (int i = n; i > 0; i--)
				list.Add(string.Format("She swallowed the {0} to catch the {1}{2}.",
					words[i][0], words[i - 1][0], words[i - 1][2])); 
			list.Add("I don't know why she swallowed the fly. Perhaps she'll die.");
		}
		return string.Join("\n", list);
	}
	public static string Song()
	{
		return string.Join("\n", from i in Enumerable.Range(1, 8) select Verse(i) + (i<8?"\n":string.Empty));
	}
}
