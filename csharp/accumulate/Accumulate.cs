using System;
using System.Collections.Generic;

public static partial class IEnumerableExtensions
{
    public static IEnumerable<T2> Accumulate<T1, T2>(this IEnumerable<T1> col, Func<T1, T2> lambda)
    {
        foreach (var x in col) yield return lambda(x);
    }
}