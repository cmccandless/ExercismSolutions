using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rectangles
{
	private static readonly HashSet<char> h = new HashSet<char>("+-");
	private static readonly HashSet<char> v = new HashSet<char>("+|");
	private static Func<List<Tuple<int, int>>, int, Tuple<int, int>> access = 
		(l, i) => i < l.Count ? l[i] : null;
	private static Func<Tuple<int, int>, int[]> f =
		t => new[] { t.Item1, t.Item2 };
	private static bool TestRange(int start, int stop, Func<int, bool> lambda)
	{
		for (int i = start; i < stop; i++) if (!lambda(i)) return false;
		return true;
	}
	private static bool IsValid(string[] input, params Tuple<int, int>[] corners)
	{
		int[] a = f(corners[0]), b = f(corners[1]);
		int[] c = f(corners[2]), d = f(corners[3]);
		return TestRange(a[0] + 1, b[0], i => h.Contains(input[a[1]][i])) &&
			TestRange(c[0] + 1, d[0], i => h.Contains(input[c[1]][i])) &&
			TestRange(b[1] + 1, d[1], i => v.Contains(input[i][b[0]])) &&
			TestRange(a[1] + 1, c[1], i => v.Contains(input[i][a[0]]));
	}
	public static int Count(string[] input)
	{
		var corners = new List<Tuple<int, int>>();
		for (int j = 0; j < input.Length; j++)
			for (int i = 0; i < input[j].Length; i++)
				if (input[j][i] == '+') corners.Add(Tuple.Create(i, j));
		int xi = 0, yi, wi, zi, count = 0;
		for (var xc = access(corners, xi); xi < corners.Count; 
			xc = access(corners, ++xi))
			for (var yc = access(corners, yi = xi + 1); yi < corners.Count; 
				yc = access(corners, ++yi))
				if (xc.Item1 < yc.Item1 && xc.Item2 == yc.Item2)
					for (var wc = access(corners, wi = yi + 1); 
						wi < corners.Count; wc = access(corners, ++wi))
						if (xc.Item1 == wc.Item1 && xc.Item2 < wc.Item2)
							for (var zc = access(corners, zi = yi + 1); 
								zi < corners.Count; zc = access(corners, ++zi))
								if (yc.Item1 == zc.Item1 && yc.Item2 < zc.Item2 &&
									wc.Item1 < zc.Item1 && wc.Item2 == zc.Item2 &&
									IsValid(input, xc, yc, wc, zc)) count++;
		return count;
	}
}