using System;
using System.Collections.Generic;
using System.Linq;

static class PascalsTriangle
{
	public static int[][] Calculate(int n)
	{
		var result = new List<int[]>();
		for (int r = 1; r <= n; r++)
		{
			var row = new int[r].Select(_ => 1).ToArray();
			if (r > 2)
			{
				var previousRow = result.Last();
				for (int c = 1; c < r - 1; c++)
				{
					row[c] = previousRow[c - 1] + previousRow[c];
				}
			}
			result.Add(row);
		}
		return result.ToArray();
	}
}
