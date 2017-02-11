using System.Collections.Generic;
using System.Linq;

public class SumOfMultiples
{
	public static int To(int[] nums, int mult)
	{
		var vals = new List<int>();
		foreach (var x in nums)
		{
			int n=x;
			while (n < mult)
			{
				vals.Add(n);
				n += x;
			}
		}
		return vals.Distinct().Sum();
	}
}
