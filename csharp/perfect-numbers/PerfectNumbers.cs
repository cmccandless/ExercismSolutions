using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum NumberType { Deficient, Perfect, Abundant }
public class PerfectNumbers
{
	public static NumberType Classify(int n)
	{
		var s = new HashSet<int>(Factors(n)).Sum() - n;
		return s < 0 ? NumberType.Deficient : (s == 0 ? NumberType.Perfect : NumberType.Abundant);
	}
	private static IEnumerable<int> Factors(int n)
	{
		yield return 1;
		for (int i=2;i<Math.Sqrt(n);i++)
		{
			if (n%i==0)
			{
				yield return i;
				yield return n / i;
			}
		}
	}
}
