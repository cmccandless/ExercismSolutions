using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.go_counting
{
	class GoCounting
	{
		public enum Player { None, Black, White, Disputed }
		private static Dictionary<char, Player> tokens = new Dictionary<char, Player>
		{
			{' ',Player.None},
			{'B',Player.Black},
			{'W',Player.White},
		};
		private Player[][] board;
		private Dictionary<Player, IEnumerable<Point>> territories = new Dictionary<Player, IEnumerable<Point>>();
		public GoCounting(string board)
		{
			this.board = (from line in board.Split('\n')
						  select line.Select(ch => tokens[ch]).ToArray()).ToArray();
		}
		public Tuple<Player, IEnumerable<Point>> TerritoryFor(Point p)
		{
			try { if (board[p.Y][p.X] != Player.None) return null; }
			catch (IndexOutOfRangeException) { return null; }
			var player = Player.None;
			var border = new Dictionary<Point, Player>();
			var pending = new HashSet<Point>();
			var invalid = new HashSet<Point>();
			var queue = new Queue<Point>();
			queue.Enqueue(p);
			while (queue.Any())
			{
				p = queue.Dequeue();
				if (board[p.Y][p.X] != Player.None) continue;
				var n = p.Neighbors;
				var t = Player.None;
				foreach (var x in n)
				{
					try { t |= board[x.Y][x.X]; }
					catch (IndexOutOfRangeException) { invalid.Add(x); }
				}
				switch (t)
				{
					case Player.Disputed:
						player = t;
						goto case Player.Black;
					case Player.None:
						pending.Add(p);
						break;
					case Player.Black:
					case Player.White:
						border[p] = t;
						break;
				}
				foreach (var x in n.Except(invalid))
				{
					if (!border.ContainsKey(x) && !pending.Contains(x) &&
						!queue.Contains(x))
						queue.Enqueue(x);
				}
			}
			if (player == Player.None)
			{
				try
				{
					var g = border.GroupBy(kvp => kvp.Value);
					player = g.Count() > 1 ? Player.Disputed : g.First().Key;
				}
				catch (InvalidOperationException) { }
			}
			return Tuple.Create((Player)((int)player % 3),
				pending.Union(border.Keys).Where(q =>
				{
					try { return board[q.Y][q.X] == Player.None; }
					catch (IndexOutOfRangeException) { return false; }
				}));
		}
		public Dictionary<Player, HashSet<Point>> Territories()
		{
			var dict = new Dictionary<Player, HashSet<Point>>();
			var visited = new HashSet<Point>();
			for (int y = 0; y < board.Length; y++)
				for (int x = 0; x < board[y].Length; x++)
				{
					var p = new Point(x, y);
					if (visited.Contains(p)) continue;
					var t = TerritoryFor(p);
					if (t != null)
					{
						foreach (var n in t.Item2)
						{
							try
							{
								dict[t.Item1].Add(n);
							}
							catch (KeyNotFoundException)
							{
								dict[t.Item1] = new HashSet<Point>();
								dict[t.Item1].Add(n);
							}
							visited.Add(n);
						}
					}
					visited.Add(p);
				}
			return dict;
		}
	}
	public class Point : IComparable<Point>, IEquatable<Point>
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
		public static Point operator +(Point a, Point b)
		{
			return new Point(a.X + b.X, a.Y + b.Y);
		}
		public static Point operator -(Point a, Point b)
		{
			return new Point(a.X - b.X, a.Y - b.Y);
		}
		public static readonly Point Origin = new Point(0, 0);
		public override string ToString()
		{
			return string.Format("({0},{1})", X, Y);
		}
		private static int[] nums = new[] { -1, 0, 1 };
		private static Point[] neighborsRelative = (from x in nums
													from y in nums
													where (x == 0 || y == 0) && x != y
													select new Point(x, y)).ToArray();
		public HashSet<Point> Neighbors
		{
			get
			{
				return new HashSet<Point>(from n in neighborsRelative select this + n);
			}
		}
		public int CompareTo(Point other)
		{
			var compare = this.X.CompareTo(other.X);
			if (compare != 0) return compare;
			return (compare << 16) + this.Y.CompareTo(other.Y);
		}
		public bool Equals(Point other)
		{
			return this.X == other.X && this.Y == other.Y;
		}
		public override bool Equals(object obj)
		{
			var other = obj as Point;
			return other != null && this.Equals(other);
		}
		public override int GetHashCode() { return (this.X << 16) + this.Y; }
	}
}