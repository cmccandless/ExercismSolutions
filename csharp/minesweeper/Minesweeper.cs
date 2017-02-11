using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Minesweeper
{
	public static string Annotate(string input)
	{
		var lines = (from line in input.Split('\n')
					 select line.ToCharArray()).ToArray();
		for (int i = 0; i < lines.Length; i++)
			for (int j = 0; j < lines[i].Length; j++)
				if (lines[i][j] == ' ')
				{
					var count = (from y in new[] { i - 1, i, i + 1 }
								 where y >= 0 && y < lines.Length
								 from x in new[] { j - 1, j, j + 1 }
								 where x >= 0 && x < lines[i].Length
								 where x != j || y != i
								 where lines[y][x] == '*'
								 select i).Count();
					lines[i][j] = count > 0 ? count.ToString()[0] : ' ';
				}
		return string.Join("\n", from line in lines select string.Join(string.Empty, line));
	}
}
