using System;
using System.Collections.Generic;

public static partial class IEnumerableExtensions
{
	public static IEnumerable<T> Accumulate<T>(this IEnumerable<T> col, Func<T,T> lambda)
	{
		foreach (var x in col) yield return lambda(x);
	}
}
