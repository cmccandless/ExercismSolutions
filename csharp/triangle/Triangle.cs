using System;
using System.Linq;
using static System.Math;

public enum TriangleKind
{
    Scalene,
    Isosceles,
    Equilateral,
}

public class Triangle
{
    private static bool Invalid(params decimal[] s) =>
        s[0] <= 0 || s[2] >= s[0] + s[1];

    private static void Swap<T>(T[] s, int a, int b)
    {
        var t = s[a];
        s[a] = s[b];
        s[b] = t;
    }

    private static decimal[] Sorted(params decimal[] s)
    {
        if (s[1] > s[2]) Swap(s, 1, 2);
        if (s[0] > s[2]) Swap(s, 0, 2);
        else if (s[0] > s[1]) Swap(s, 0, 1);
        return s;
    }

    public static TriangleKind Kind(decimal a, decimal b, decimal c) =>
        Kind(Sorted(a, b, c));

    public static TriangleKind Kind(decimal[] s)
    {
        if (Invalid(s)) throw new TriangleException();
        return (TriangleKind)((s[0] == s[1]).ToInt32() +
            (s[1] == s[2]).ToInt32());
    }
}

static partial class BoolExtensions
{
    public static int ToInt32(this bool b) => Convert.ToInt32(b);
}

public class TriangleException : Exception { }
