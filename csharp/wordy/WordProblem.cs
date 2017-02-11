using System;
using System.Linq;
using System.Text.RegularExpressions;

static class WordProblem
{
	private const RegexOptions REGEX_OPTIONS = RegexOptions.Compiled | RegexOptions.IgnoreCase;
	private static Regex rgxEquationParts = new Regex(@"-?[\d]+|plus|minus|multiplied by|divided\sby", REGEX_OPTIONS);
	public static int Solve(string wordProblem)
	{
		var result = 0;
		var op = "plus";
		var matches = rgxEquationParts.Matches(wordProblem).Cast<Match>();
		if (matches.Count() < 3) throw new ArgumentException();
		foreach (var match in matches)
		{
			int value;
			if (int.TryParse(match.Groups[0].Value, out value))
			{
				switch (op)
				{
					case "plus":
						result += value;
						break;
					case "minus":
						result -= value;
						break;
					case "multiplied by":
						result *= value;
						break;
					case "divided by":
						result /= value;
						break;
				}
			}
			else op = match.Groups[0].Value;
		}
		return result;
	}
}
