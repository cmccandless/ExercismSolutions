using System;

public enum TriangleKind
{
    Scalene,
    Isosceles,
    Equilateral,
}

public static class Triangle
{
    private static int ToInt(this bool b) => Convert.ToInt32(b);

    private static bool Invalid(params decimal[] s) => s[0] <= 0 || s[2] >= s[0] + s[1];

    private static T[] Sort<T>(this T[] s, int a, int b) where T : IComparable
    {
        if (s[a].CompareTo(s[b]) > 0)
        {
            var t = s[a];
            s[a] = s[b];
            s[b] = t;
        }
        return s;
    }

    private static decimal[] Sorted(params decimal[] s) => s.Sort(1, 2).Sort(0, 1).Sort(1, 2);

    public static TriangleKind Kind(decimal a, decimal b, decimal c) => KindSorted(Sorted(a, b, c));

    private static TriangleKind KindSorted(decimal[] s)
    {
        if (Invalid(s)) throw new TriangleException();
        return (TriangleKind)((s[0] == s[1]).ToInt() +
            (s[1] == s[2]).ToInt());
    }
}

public class TriangleException : Exception { }
