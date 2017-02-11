using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Grains
{
	public static ulong Square(int n)
	{
		return (ulong)Math.Pow(2,n - 1);
	}

	public static ulong Total()
	{
		return Enumerable.Range(1, 64).Aggregate((ulong)0, (x, y) => x + Square(y));
	}
}
