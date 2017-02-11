using System.Collections.Generic;
using System.Linq;

static class Complement
{
	private static Dictionary<char, char> complement = new Dictionary<char, char>()
	{
		{ 'G', 'C'},
		{ 'C', 'G'},
		{ 'T', 'A'},
		{ 'A', 'U'},
	};
	public static string OfDna(string dna)
	{
		return string.Join(string.Empty, dna.Select(ch => complement[ch]));
	}
}
