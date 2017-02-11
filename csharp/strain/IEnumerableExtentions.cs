using System;
using System.Collections.Generic;
using System.Linq;

public static partial class IEnumerableExtensions
{
	public static IEnumerable<T> Keep<T>(this IEnumerable<T> set, Func<T, bool> lambda)
	{
		return new List<T>(set.Where(lambda));
	}
	public static IEnumerable<T> Discard<T>(this IEnumerable<T> set, Func<T, bool> lambda)
	{
		return new List<T>(set.Except(set.Where(lambda)));
	}
}
