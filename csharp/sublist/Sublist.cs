using System;
using System.Collections.Generic;

public enum SublistType { Equal, Unequal, Sublist, Superlist };
public static class Sublist
{
	public static SublistType Classify<T>(List<T> a, List<T> b) where T : IEquatable<T>
	{
		if (a.Count > b.Count && Classify(b, a) == SublistType.Sublist)
			return SublistType.Superlist;
		for (int j,i = 0; i < b.Count - a.Count + 1; i++)
		{
            for (j = 0; j < a.Count && b[i + j].Equals(a[j]); j++) ;
			if (j == a.Count) return j == b.Count ? SublistType.Equal : SublistType.Sublist;
		}
		return SublistType.Unequal;
	}
}
