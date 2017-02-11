using System.Collections.Generic;

static class Beer
{
	public static string Verse(int verse)
	{
		var bottles = Bottles(verse);
		return string.Format("{0} on the wall, {1}.\n" +
			"{2}, {3} on the wall.\n",
			bottles,
			bottles.ToLower(),
			Action(verse),
			Bottles(verse - 1).ToLower());
	}

	private static string Bottles(int verse)
	{
		return verse == 0 ?
			"No more bottles of beer" :
			string.Format("{0} bottle{1} of beer", (verse + 100) % 100, verse != 1 ? "s" : string.Empty);
	}

	private static string Action(int verse)
	{
		return verse == 0 ?
			"Go to the store and buy some more" :
			"Take " + (verse == 1 ? "it" : "one") + " down and pass it around";
	}

	public static string Sing(int start, int stop)
	{
		return string.Join(string.Empty, Verses(start, stop));
	}

	private static IEnumerable<string> Verses(int start, int stop)
	{
		for (int i = start; (start < stop && i <= stop) || i >= stop; i += start < stop ? 1 : -1)
		{
			yield return Verse(i) + "\n";
		}
	}
}
