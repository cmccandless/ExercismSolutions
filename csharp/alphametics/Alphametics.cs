using System;
using System.Collections.Generic;
using System.Linq;

public class Alphametics
{
	public static Dictionary<char, int> Solve(string expr, Dictionary<char, int> dict = null, HashSet<char> invalidZero = null)
	{
		if (dict == null) dict = new Dictionary<char, int>();
		if (invalidZero == null)
			invalidZero = new HashSet<char>(expr.Split(' ').Where(w => !w.Contains('+') && !w.Contains('=')).Select(w => w[0]));
		var letters = new HashSet<char>(expr.Where(c => char.IsLetter(c)));
		var attempted = letters.FirstOrDefault(ch => !dict.ContainsKey(ch));
		if (attempted == default(char))
		{
			var parts = expr.Split(new[] { " == " }, StringSplitOptions.None);
			if (dict[parts[1][0]] == 0) return null;
			var equal = int.Parse(string.Join("", parts[1].Select(ch => dict[ch])));
			var terms = parts[0].Split(new[] { " + " }, StringSplitOptions.None);
			if (terms.Any(t => dict[t[0]] == 0)) return null;
			var termSum = terms.Sum(w => int.Parse(string.Join("", w.Select(ch => dict[ch]))));
			if (equal.Equals(termSum)) return dict;
		}
		else
		{
			var values = new HashSet<int>(dict.Values);
			for (int x = invalidZero.Contains(attempted) ? 1 : 0; x < 10; x++)
			{
				if (values.Contains(x)) continue;
				dict[attempted] = x;
				var result = Solve(expr, dict, invalidZero);
				if (result != null) return dict;
			}
			dict.Remove(attempted);
		}
		if (dict.Count == 0) throw new ArgumentException();
		return null;
	}
}
