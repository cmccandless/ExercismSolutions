using System.Linq;

public class Hamming
{
	internal static int Compute(string a, string b)
	{
		return Enumerable.Range(0, a.Length).Count(i => !a[i].Equals(b[i]));
	}
}
