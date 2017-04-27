using System;
using System.Collections.Generic;

public class ListOps
{
    public static int Length<T>(List<T> list) => list.Count;
    public static IEnumerable<T> Reverse<T>(IEnumerable<T> list) => Reverse(new List<T>(list));
    public static IEnumerable<T> Reverse<T>(List<T> list)
    {
        for (int i = Length(list) - 1; i >= 0; i--) yield return list[i];
    }
    public static IEnumerable<T2> Map<T1, T2>(Func<T1, T2> f, IEnumerable<T1> list)
    {
        foreach (var x in list) yield return f(x);
    }
    public static IEnumerable<T> Append<T>(IEnumerable<T> list1, IEnumerable<T> list2) =>
        Concat(new[] { list1, list2 });
    public static IEnumerable<T> Filter<T>(Func<T, bool> f, IEnumerable<T> list)
    {
        foreach (var x in list) if (f(x)) yield return x;
    }
    public static T2 Foldl<T1, T2>(Func<T2, T1, T2> f, T2 _default, IEnumerable<T1> list)
    {
        foreach (var x in list) _default = f(_default, x);
        return _default;
    }
    public static T2 Foldr<T1, T2>(Func<T1, T2, T2> f, T2 _default, IEnumerable<T1> list) =>
         Foldl((x, y) => f(y, x), _default, Reverse(list));
    public static IEnumerable<T> Concat<T>(IEnumerable<IEnumerable<T>> lists)
    {
        foreach (var list in lists) foreach (var item in list) yield return item;
    }
}
