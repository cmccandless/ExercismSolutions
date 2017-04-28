using System;
using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    private static Tuple<int, int>[] neighbors = new[] { -1, 0, 1 }.SelectMany(y =>
        new[] { -1, 0, 1 }.Where(x => x != 0 || y != 0).Select(x => Tuple.Create(y, x))).ToArray();

    private static char[] SpaceToZeroA(this string s) => s.Replace(' ', '0').ToArray();

    private static string ZeroToSpace(this string s) => s.Replace('0', ' ');

    private static IEnumerable<char[]> GetLines(this string s) => s.Split('\n').Select(SpaceToZeroA);

    private static string JoinLines(this IEnumerable<string> lines) => string.Join("\n", lines);

    private static void Increment(this char[][] lines, int y, int x)
    {
        try { if (lines[y][x] != '*') lines[y][x]++; }
        catch (IndexOutOfRangeException) { }
    }

    private static void IncrementNeighbors(this char[][] lines, int i, int j)
    {
        foreach (var n in neighbors) lines.Increment(n.Item1 + i, n.Item2 + j);
    }

    private static IEnumerable<string> Annotate(IEnumerable<char[]> input)
    {
        var lines = input.ToArray();
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
                if (lines[i][j] == '*') lines.IncrementNeighbors(i, j);
            if (i > 0) yield return new string(lines[i - 1]);
        }
        yield return new string(lines.Last());
    }

    public static string Annotate(string input) => Annotate(input.GetLines()).Select(ZeroToSpace).JoinLines();
}
