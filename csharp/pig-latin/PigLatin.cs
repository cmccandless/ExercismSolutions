using System.Linq;

static class PigLatin
{
	private static string[] vowels = new string[] { "a", "e", "i", "o", "u", "yt", "xr" };
	private static string[] exceptions = new string[] { "ch", "qu", "squ", "sch", "thr", "th", "sh" };
	public static string Translate(string phrase)
	{
		return string.Join(" ", phrase.Split(' ').Select(w => TranslateWord(w)));
	}
	private static string TranslateWord(string word)
	{
		if (vowels.Any(v => word.StartsWith(v)))
		{
			return word + "ay";
		}
		else
		{
			var vowelIndex = 1;
			foreach (var ex in exceptions)
			{
				if (word.StartsWith(ex))
				{
					vowelIndex = ex.Length;
					break;
				}
			}
			return word.Substring(vowelIndex) + word.Substring(0, vowelIndex) + "ay";
		}
	}
}
