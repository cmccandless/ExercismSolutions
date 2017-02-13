using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.word_search
{
    public class WordSearch
    {
        private string[] lines;

        private static readonly int[] vals = new[] { -1, 0, 1 };
        private static readonly Point[] directions =
            (from x in vals
             from y in vals
             where x != 0 || y != 0
             select new Point(x, y)).ToArray();

        private static readonly Point adj = new Point(1, 1);

        public WordSearch(string puzzle) { lines = puzzle.Split('\n'); }

        public Tuple<Point, Point> Find(string word) => FindAll(word).FirstOrDefault();

        private bool InRange(Point p) => p.Y >= 0 && p.Y < lines.Length &&
            p.X >= 0 && p.X < lines[p.Y].Length;

        public IEnumerable<Tuple<Point, Point>> FindAll(string word) =>
            from y1 in Enumerable.Range(0, lines.Length)
            from x1 in Enumerable.Range(0, lines[y1].Length)
            let p0 = new Point(x1, y1)
            where word[0] == lines[y1][x1]
            from dir in directions
            where (from i in Enumerable.Range(1, word.Length - 1)
                   let pi = p0 + dir * i
                   select InRange(pi) && word[i] == lines[pi.Y][pi.X]).All(t=>t)
            select Tuple.Create(p0 + adj, p0 + dir * (word.Length - 1) + adj);
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            var other = obj as Point;
            return other != null && X == other.X && Y == other.Y;
        }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static Point operator +(Point a, Point b) =>
            new Point(a.X + b.X, a.Y + b.Y);
        public static Point operator *(Point a, int k) =>
            new Point(a.X * k, a.Y * k);
        public static Point operator *(int k, Point a) => a * k;
        public override string ToString() =>
            string.Format("({0},{1})", X, Y);
    }
}