using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dominoes
{
	public static bool CanChain(Tuple<int, int>[] dominoes)
	{
		if (dominoes.Length == 0) return true;
		List<Tuple<int, int>> results;
		if (!TryChain(dominoes, out results)) return false;
		return results.FirstOrDefault(t => t.Item2 == t.Item1) != null;
	}
	private static bool TryChain(Tuple<int, int>[] dominoes, out List<Tuple<int, int>> c)
	{
		if (dominoes.Length < 2)
		{
			c = dominoes.ToList();
			return true;
		}
		if (dominoes.Length == 2) return TryChain(dominoes[0], dominoes[1], out c);
		c = new List<Tuple<int, int>>();
		for (int i = 0; i < dominoes.Length; i++)
		{
			var set = dominoes.ToList();
			var t1 = set[i];
			set.RemoveAt(i);
			List<Tuple<int, int>> subResults;
			if (!TryChain(set.ToArray(), out subResults)) continue;
			foreach (var t2 in subResults)
			{
				List<Tuple<int, int>> matches;
				if (TryChain(t1, t2, out matches)) c.AddRange(matches);
			}
		}
		return c.Count > 0;
	}
	private static bool TryChain(Tuple<int, int> a, Tuple<int, int> b, out List<Tuple<int, int>> c)
	{
		c = new List<Tuple<int, int>>();
		if (a.Item1 == b.Item1) c.Add(Tuple.Create(a.Item2, b.Item2));
		if (a.Item1 == b.Item2) c.Add(Tuple.Create(a.Item2, b.Item1));
		if (a.Item2 == b.Item1) c.Add(Tuple.Create(a.Item1, b.Item2));
		if (a.Item2 == b.Item2) c.Add(Tuple.Create(a.Item1, b.Item1));
		return c.Count > 0;
	}
}

