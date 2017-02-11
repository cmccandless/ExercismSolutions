using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum SublistType { Equal, Unequal, Sublist, Superlist };
public class Sublist
{
	public static SublistType Classify<T>(List<T> a, List<T> b) where T : IComparable
	{
		if (a.Count == b.Count)
			return a.SequenceEqual(b) ? SublistType.Equal : SublistType.Unequal;
		if (a.Count == 0) return SublistType.Sublist;
		if (a.Count > b.Count && Classify(b, a) == SublistType.Sublist)
			return SublistType.Superlist;
		for (int i = 0; i < b.Count - a.Count + 1; i++)
		{
			int j;
			for (j = 0; j < a.Count; j++)
			{
				if (b[i + j].CompareTo(a[j]) != 0) break;
			}
			if (j == a.Count) return SublistType.Sublist;
		}
		return SublistType.Unequal;
	}
}
