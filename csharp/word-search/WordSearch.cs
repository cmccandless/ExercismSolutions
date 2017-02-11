using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.word_search
{
public class WordSearch
{
	private string[] lines;
	private static readonly Point[] directions =
		(from x in new[] { -1, 0, 1 }
		 from y in new[] { -1, 0, 1 }
		 where x != 0 || y != 0
		 select new Point(x, y)).ToArray();
	private static readonly Point adj = new Point(1, 1);
	public WordSearch(string puzzle) { this.lines = puzzle.Split('\n'); }
	public Tuple<Point, Point> Find(string word)
	{
		for (int y1 = 0; y1 < lines.Length; y1++)
			for (int x1 = 0; x1 < lines[y1].Length; x1++)
			{
				var p1 = new Point(x1, y1);
				if (word[0] != lines[y1][x1]) continue;
				foreach (var dir in directions)
				{
					var i = 1;
					var p2 = p1 + dir;
					try
					{
						while (lines[p2.Y][p2.X] == word[i++])
						{
							if (i == word.Length) return
								new Tuple<Point, Point>(p1 + adj, p2 + adj);
							p2 += dir;
						}
					}
					catch (IndexOutOfRangeException) { continue; }
				}
			}
		return null;
	}
}
public class Point
{
	public int X { get; set; }
	public int Y { get; set; }
	public Point(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}
	public override bool Equals(object obj)
	{
		var other = obj as Point;
		if (other == null) return false;
		return this.X == other.X && this.Y == other.Y;
	}
	public override int GetHashCode() { return base.GetHashCode(); }
	public static Point operator +(Point a, Point b)
	{
		return new Point(a.X + b.X, a.Y + b.Y);
	}
	public override string ToString()
	{
		return string.Format("({0},{1})", X, Y);
	}
}
}