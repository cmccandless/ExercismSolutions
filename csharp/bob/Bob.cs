using System.Linq;

public class Bob
{
	private static string[] responses = new string[]
		{
			"Sure.",
			"Whoa, chill out!",
			"Fine. Be that way!",
			"Whatever.",
		};

	internal static string Hey(string query)
	{
		query = query.Trim();
		return responses[
			query.Equals(string.Empty) ? 2 :
			(query.Any(ch => char.IsLetter(ch)) && query.ToUpper().Equals(query) ? 1 :
			(query.EndsWith("?") ? 0 :
			3))
			];
		//if (query.Equals(string.Empty)) return responses[2];
		//var hasLetters = query.Any(ch => char.IsLetter(ch));
		//if (hasLetters && query.ToUpper().Equals(query)) return responses[1];
		//if (query.EndsWith("?")) return responses[0];
		//return responses[3];
	}
}
