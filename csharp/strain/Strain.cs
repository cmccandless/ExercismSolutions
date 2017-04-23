using System;
using System.Collections.Generic;

public static partial class IEnumerableExtensions
{
    private static IEnumerable<T> Filter<T>(this IEnumerable<T> set, Func<T, bool> lambda, bool positive = true)
    {
        foreach (var item in set)
            if (lambda(item) == positive) yield return item;
    }

    public static IEnumerable<T> Keep<T>(this IEnumerable<T> set, Func<T, bool> lambda) =>
        set.Filter(lambda);

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> set, Func<T, bool> lambda) =>
        set.Filter(lambda, false);
}