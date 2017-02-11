using System;
using System.Linq;

static class Trinary
{
	public static int ToDecimal(string trinary)
	{
		if (trinary.Any(ch => ch > '2' || ch < '0')) return 0;
		return trinary.Select((t, i) => (t - '0') * (int)Math.Pow(3,trinary.Length-i-1)).Sum();
	}
}