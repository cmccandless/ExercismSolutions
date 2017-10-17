using System.Linq;

public class Anagram
{
    private string Word { get; set; }
    private string Sorted { get; set; }

    public Anagram(string word)
    {
        Word = word.ToLower();
        Sorted = Word.SortLetters();
    }

    public string[] Anagrams(string[] candidates) =>
        (from candidate in candidates
         let lowered = candidate.ToLower()
         where !lowered.Equals(Word)
         where lowered.SortLetters().Equals(Sorted)
         select candidate).ToArray();
}

public static class Ext
{
    public static string SortLetters(this string word) => string.Join(string.Empty, word.OrderBy(c => c));
}
