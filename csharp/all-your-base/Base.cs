using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Base
{
	private static Func<int, int[], int[]> ToBase10 = (inputBase,digits) => digits.Reverse().Select((x, i) => x * Math.Pow(inputBase, i))
				.Sum().ToString().Select(c => int.Parse(c.ToString())).ToArray();
	private static int[] FromBase10(int[] digits, int outputBase)
	{
		var a = new List<int>();
		var s = int.Parse(string.Join("", digits));
		var i = 1;
		while (s > i) i *= outputBase;
		while (s > 0)
		{
			i /= outputBase;
			a.Add(0);
			while (s >= i)
			{
				s -= i;
				a[a.Count - 1]++;
			}
		}
		while (i > 1)
		{
			i /= outputBase;
			a.Add(0);
		}
		return a.ToArray();
	}
	private static bool Validate(int inputBase, int[] digits, int outputBase)
	{
		return inputBase >= 2 && outputBase >= 2 && digits.Length != 0 &&
		digits.First() != 0 && digits.Sum() != 0 &&
		digits.All(x => x >= 0 && x < inputBase);
	}
	public static int[] Rebase(int inputBase, int[] digits, int outputBase)
	{
		if (!Validate(inputBase, digits, outputBase)) throw new ArgumentException();
		if (inputBase != 10) digits = ToBase10(inputBase, digits);
		if (outputBase != 10) digits = FromBase10(digits, outputBase);
		return digits;
	}
}
