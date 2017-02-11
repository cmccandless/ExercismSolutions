using System.Linq;
using System.Text.RegularExpressions;

public class RunLengthEncoding
{
	public static string Encode(string input)
	{
		return string.Join(string.Empty,
			from Match match in Regex.Matches(input, @"(?<c>.)\k<1>*")
			let value = match.Groups[0].Value
			let count = value.Length > 1 ? value.Length.ToString() : string.Empty
			select string.Format("{0}{1}", count, value[0]));
	}
	public static string Decode(string input)
	{
		return string.Join(string.Empty,
			from Match match in Regex.Matches(input, @"(\d+)?([^\d])")
			let values = (from Group grp in match.Groups
						  select grp.Value).ToArray()
			let count = values[1].Length > 0 ? int.Parse(values[1]) : 1
			select string.Join(string.Empty, from _ in new int[count]
											 select values[2]));
	}
}
