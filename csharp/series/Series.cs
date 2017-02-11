using System;
using System.Collections.Generic;
using System.Linq;

class Series
{
	private int[] Numbers { get; set; }
	public Series(string seriesText)
	{
		Numbers = seriesText.ToCharArray().Select(ch => ch - '0').ToArray();
	}

	public int[][] Slices(int n)
	{
		if (n > Numbers.Length) throw new ArgumentException();
		return Enumerable.Range(0, Numbers.Length + 1 - n)
			.Select(i => Numbers.Slice(i, n).ToArray()).ToArray();
	}	
}

public static partial class IEnumerableExtensions
{
	public static IEnumerable<T> Slice<T>(this IEnumerable<T> set, int start, int count)
	{
		return set.Skip(start).Take(count);
	}
}
