using System;

public static class Triangle
{
    private static int ToInt(this bool b) => Convert.ToInt32(b);

    private static bool Invalid(params double[] s) => s[0] <= 0 || s[2] >= s[0] + s[1];

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

    private static double[] Sorted(double[] s) => s.Sort(1, 2).Sort(0, 1).Sort(1, 2);

    private static int Kind(double[] s)
    {
        s = Sorted(s);
        return Invalid(s) ? -1 : ((s[0] == s[1]).ToInt() + (s[1] == s[2]).ToInt());
    }

    public static bool IsEquilateral(params double[] s) => Kind(s) == 2;

    public static bool IsIsosceles(params double[] s) => Kind(s) > 0;

    public static bool IsScalene(params double[] s) => Kind(s) == 0;
}
