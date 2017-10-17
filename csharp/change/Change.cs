using System;
using System.Linq;

public static class Change
{
    private static void Validate(int targetValue, int[] coinSet)
    {
        if (targetValue < 0) throw new ArgumentException("Target must be a positive value.");
        if (coinSet.Length > 0 && targetValue > 0 && targetValue < coinSet[0])
            throw new ArgumentException("Target smaller than smallest coin in set.");
    }

    private static int Size<T>(this T[] a, int defaultValue = 0x7FFFFFFF) => a?.Length ?? defaultValue;

    private static void SetPosition(int targetValue, int coin, int[,][] m, int t, int c)
    {
        var sx = new[] { coin };
        if (t == coin)
        {
            m[t, c] = sx;
            return;
        }
        if (m[t, c].Size() > m[t, c - 1].Size()) m[t, c] = m[t, c - 1];
        for (int t2 = 0; t2 < t; t2++)
        {
            if (t2 + coin != t) continue;
            if (m[t, c].Size() > (uint)m[t2, c].Size() + 1)
                m[t, c] = m[t2, c].Concat(sx).ToArray();
        }
    }

    private static void SetRow(int targetValue, int[] coinSet, int[,][] m, int t)
    {
        for (int c = 1; c <= coinSet.Length; c++)
            SetPosition(targetValue, coinSet[c - 1], m, t, c);
    }

    public static int[] Calculate(int targetValue, int[] coinSet)
    {
        Validate(targetValue, coinSet);
        var m = new int[targetValue + 1, coinSet.Length + 1][];
        for (int c = 0; c <= coinSet.Length; c++) m[0, c] = new int[0];
        for (int t = 1; t <= targetValue; t++) SetRow(targetValue, coinSet, m, t);
        return m[targetValue, coinSet.Length];
    }
}
