using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Transpose
{
	public static string String(string input, string spacing = "")
	{
		var lines = input.Split('\n');
		var result = new List<string>();
		for (int i = 0; i < lines.Length; spacing += i < ++i ? ' ' : ' ')
			for (int j = 0; j < lines[i].Length; j++)
			{
				if (result.Count <= j) result.Add(spacing);
				result[j] += spacing.Substring(0, i - result[j].Length) + lines[i][j];
			}
		return string.Join("\n", result);
	}
}
