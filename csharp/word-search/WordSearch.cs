using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private string[] lines;
    private int Height => lines.Length;
    private int Width => lines[0].Length;

    private static readonly int[] vals = new[] { -1, 0, 1 };
    private static readonly Point[] directions =
        (from x in vals
         from y in vals
         where x != 0 || y != 0
         select new Point(x, y)).ToArray();

    public WordSearch(string puzzle) { lines = puzzle.Split('\n'); }

    public Tuple<Tuple<int, int>, Tuple<int, int>> Find(string word) => FindAll(word).FirstOrDefault();

    private bool IsMatch(string word, Point start, Point dir)
    {
        var pi = new Point(start);
        for (int i = 1; i < word.Length; i++)
        {
            pi += dir;
            if (!pi.InRange(Height, Width) || word[i] != lines.At(pi)) return false;
        }
        return true;
    }

    public IEnumerable<Tuple<Tuple<int, int>, Tuple<int, int>>> FindAll(string word) =>
        from y1 in Enumerable.Range(0, Height)
        from x1 in Enumerable.Range(0, Width)
        let p0 = new Point(x1, y1)
        where word[0] == lines.At(p0)
        from dir in directions
        where IsMatch(word, p0, dir)
        let stop = p0 + (word.Length - 1) * dir
        select Tuple.Create(p0.AsTuple, stop.AsTuple);
}
public static class Ext { public static char At(this string[] m, Point p) => m[p.Y][p.X]; }
public class Point
{
    public int X, Y;

    public Point(int x, int y) { X = x; Y = y; }
    public Point(Point p) : this(p.X, p.Y) { }

    public override bool Equals(object obj) => Equals(obj as Point);
    public bool Equals(Point other) => X.Equals(other?.X) && Y.Equals(other.Y);
    public override int GetHashCode() => base.GetHashCode();

    public static Point operator +(Point a, Point b) =>
        new Point(a.X + b.X, a.Y + b.Y);
    public static Point operator *(int k, Point a) => new Point(a.X * k, a.Y * k);

    public override string ToString() => $"({X},{Y})";

    public Tuple<int, int> AsTuple => Tuple.Create(X + 1, Y + 1);

    public bool InRange(int yMax, int xMax, int yMin = 0, int xMin = 0) =>
        Y >= yMin && Y < yMax && X >= xMin && X < xMax;
}
