using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class Grep
{
//	- `-n` Print the line numbers of each matching line.
//- `-l` Print only the names of files that contain at least one matching line.
//- `-i` Match line using a case-insensitive comparison.
//- `-v` Invert the program -- collect all lines that fail to match the pattern.
//- `-x` Only match entire lines, instead of lines that contain a match.
	public static string Find(string pattern, string flags, string[] files)
	{
		var results = new List<string>();
		var opts = RegexOptions.None;
		if (flags.Contains("-i")) opts |= RegexOptions.IgnoreCase;
		if (flags.Contains("-v")) pattern = string.Format("^(?!.*{0}).*$",pattern);
		else if (flags.Contains("-x")) pattern = string.Format("^{0}$", pattern);
		var lineNos = flags.Contains("-n");
		var fileNamesOnly = flags.Contains("-l");
		var rgx = new Regex(pattern,opts);
		foreach (var file in files)
		{
			var lines = File.ReadAllLines(file);
			for (int i = 0; i < lines.Length; i++)
			{
				var line = lines[i];
				var match = rgx.Match(line);
				if (match.Success)
				{
					if (fileNamesOnly) 
					{
						results.Add(file);
						break;
					}
					results.Add(string.Format("{0}{1}{2}", files.Length > 1 ? file+":" : string.Empty,
						lineNos ? string.Format("{0}:",i+1) : string.Empty,line));
				}
			}
		}
		results.Add(string.Empty);
		return string.Join("\n", results);
	}
}
