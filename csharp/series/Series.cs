using System;
using System.Linq;

public class Series
{
    private int[] Numbers { get; set; }
    public Series(string seriesText)
    {
        Numbers = seriesText.Select(ch => ch - '0').ToArray();
    }

    public int[] Slice(int i, int n) => Numbers.Skip(i).Take(n).ToArray();

    public int[][] Slices(int n)
    {
        if (n > Numbers.Length) throw new ArgumentException();
        return Enumerable.Range(0, Numbers.Length + 1 - n)
            .Select(i => Slice(i, n)).ToArray();
    }
}
