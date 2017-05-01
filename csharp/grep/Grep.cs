using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Grep
{
    private static List<string> CreateList(params string[] a) => a.Where(s => s != null).ToList();

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
		if (flags.Contains("-v")) pattern = $"^(?!.*{pattern}).*$";
		else if (flags.Contains("-x")) pattern = $"^{pattern}$";
		var lineNos = flags.Contains("-n");
		var fileNamesOnly = flags.Contains("-l");
        var multiFile = files.Length > 1;
		var rgx = new Regex(pattern,opts);
		foreach (var file in files)
        {
            var lines = File.ReadAllLines(file);
			for (var i = 0; i < lines.Length; i++)
			{
				var line = lines[i];
				if (rgx.IsMatch(line))
				{
					if (fileNamesOnly) 
					{
						results.Add(file);
						break;
                    }
                    results.Add(string.Join(":", CreateList(multiFile ? file : null, lineNos ? $"{i + 1}" : null, line)));
				}
			}
		}
		results.Add(string.Empty);
		return string.Join("\n", results);
	}
}
