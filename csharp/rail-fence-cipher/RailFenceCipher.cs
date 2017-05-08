using System;
using System.Collections.Generic;
using System.Text;

public class RailFenceCipher
{
    private readonly int nRails;
    public RailFenceCipher(int nRails) { this.nRails = nRails; }

    private T[] TraverseRails<T>(int n, Func<int, int, T[], T> f)
    {
        var a = new T[nRails];
        int r = 0, d = 1;
        for (int i = 0; i < n; i++)
        {
            a[r] = f(i, r, a);
            r += d;
            if (r < 0) r = d = 1;
            else if (r == nRails)
            {
                d = -1;
                r = nRails - 2;
            }
        }
        return a;
    }

    public string Encode(string str) =>
        string.Join("", TraverseRails<string>(str.Length, (i, r, a) => a[r] + str[i]));

    public string Decode(string str)
    {
        var railCounts = TraverseRails<int>(str.Length, (i, r, a) => a[r] + 1);
        var rails = new Queue<char>[nRails];
        var s = new Queue<char>(str);
        for (int i = 0; i < nRails; i++) rails[i] = new Queue<char>(s.DequeueM(railCounts[i]));
        var result = new StringBuilder();
        TraverseRails<bool>(str.Length, (i, r, a) => null == result.Append(rails[r].Dequeue()));
        return result.ToString();
    }
}

public static class Ext
{
    public static IEnumerable<T> DequeueM<T>(this Queue<T> q, int n)
    {
        while (n-- > 0 && q.Count > 0) yield return q.Dequeue();
    }
}
