using System;
using System.Collections.Generic;
using System.Linq;

class Triplet
	{
		public int[] Sides { get; set; }
		public Triplet(params int[] sides)
		{
			Sides = sides;
		}

		public int Sum()
		{
			return Sides.Sum();
		}

		public bool IsPythagorean()
		{
			return Sides[0] * Sides[0] + Sides[1] * Sides[1] == Sides[2] * Sides[2];
		}

		public int Product()
		{
			return Sides.Aggregate(1, (x, y) => x * y);
		}

		public static IEnumerable<Triplet> Where(int sum = 0, int minFactor = 1, int maxFactor = int.MaxValue)
		{
			for (int a = minFactor; a < maxFactor; a++)
			{
				for (int b = a; b < maxFactor; b++)
				{
					var c = Math.Sqrt(a * a + b * b);
					if (Math.Truncate(c) != c) continue;
					var t = new Triplet(a, b, (int)c);
					if (sum < 1 || t.Sum() == sum)
						yield return t;
				}
			}
		}
	}
