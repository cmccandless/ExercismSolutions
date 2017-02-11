using System.Linq;

public class Anagram
{
	private string Word { get; set; }
	private string Sorted { get; set; }

	public Anagram(string word)
	{
		Word = word.ToLower();
		Sorted = SortLetters(Word);
	}

	internal string[] Match(string[] candidates)
	{
		return (from _word in candidates
				let word = _word.ToLower()
				where !word.Equals(Word)
				where SortLetters(word).Equals(Sorted)
				select _word).ToArray();
	}

	private string SortLetters(string word)
	{
		return string.Join(string.Empty, word.OrderBy(c => c));
	}
}
