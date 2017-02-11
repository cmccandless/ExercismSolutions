using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Change
{
	public static int[] Calculate(int target, int[] actual)
	{
		if (target < 0 || (actual.Length > 0 && target > 0 &&
			target < actual.First())) throw new ArgumentException();
		var m = new int[target + 1, actual.Length + 1][];
		for (int j = 0; j <= actual.Length; j++) m[0, j] = new int[0];
		for (int i = 1; i <= target; i++)
			for (int j = 1; j <= actual.Length; j++)
			{
				var x = actual[j - 1];
				if (i == x) m[i, j] = new[] { x };
				if (m[i, j - 1] != null && 
					(m[i, j] == null || m[i, j].Length > m[i, j - 1].Length))
						m[i, j] = m[i, j - 1];
				for (int i2 = 0; i2 < i; i2++)
					if (m[i2, j] != null && i2 + x == i &&
						(m[i, j] == null || m[i, j].Length > m[i2, j].Length + 1))
						m[i, j] = m[i2, j].Concat(new[] { x }).ToArray();
			}
		return m[target, actual.Length];
	}
}
