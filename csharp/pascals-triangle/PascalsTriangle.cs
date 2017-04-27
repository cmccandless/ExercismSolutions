using System.Linq;

public static class PascalsTriangle
{
    private static bool InRange(this int x, int high, int low = 0) => x > low && x < high;

    private static int Sum(this int[] p, int c) => p[c - 1] + p[c];

    private static int Cell(this int[][] a, byte _, int c) => c.InRange(a.Length) ? a[a.Length - 1].Sum(c) : 1;

    private static int[] NextRow(this int[][] a) => new byte[a.Length + 1].Select(a.Cell).ToArray();

    private static int[][] GenTriangle(int[][] a, byte _) => a.Concat(new[] { a.NextRow() }).ToArray();

    public static int[][] Calculate(int n) => new byte[n].Aggregate(new int[0][], GenTriangle);
}
