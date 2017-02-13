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
		return (from candidate in candidates
				let candidateL = candidate.ToLower()
				where !candidateL.Equals(Word)
				where SortLetters(candidateL).Equals(Sorted)
				select candidate).ToArray();
	}

	private string SortLetters(string word) => string.Join(string.Empty, word.OrderBy(c => c));
}
