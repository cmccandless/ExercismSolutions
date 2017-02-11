using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListOps
{
	public static int Length<T>(List<T> list)
	{
		return list.Count;
	}
	public static List<T> Reverse<T>(List<T> list)
	{
		var rev = new List<T>();
		for (int i = Length(list) - 1; i >= 0; i--) rev.Add(list[i]);
		return rev;
	}
	public static List<T2> Map<T1, T2>(Func<T1, T2> lambda, List<T1> list)
	{
		var result = new List<T2>();
		for (int i = 0; i < Length(list); i++) result.Add(lambda(list[i]));
		return result;
	}
	public static List<T> Append<T>(List<T> list1, List<T> list2)
	{
		var result = new List<T>(list1);
		for (int i = 0; i < Length(list2); i++) result.Add(list2[i]);
		return result;
	}
	public static List<T> Filter<T>(Func<T,bool> lambda, List<T> list)
	{
		var result = new List<T>();
		for (int i = 0; i < Length(list); i++)
			if (lambda(list[i])) result.Add(list[i]);
		return result;
	}
	public static T2 Foldl<T1,T2>(Func<T2,T1,T2> lambda, T2 _default, List<T1> list)
	{
		for (int i = 0; i < Length(list); i++) _default = lambda(_default, list[i]);
		return _default;
	}
	public static T2 Foldr<T1,T2>(Func<T1,T2,T2> lambda, T2 _default, List<T1> list)
	{
		var s = new Stack<T1>(list);
		while (s.Count > 0) _default = lambda(s.Pop(), _default);
		return _default;
	}
	public static List<T> Concat<T>(List<List<T>> lists)
	{
		var result = new List<T>();
		foreach (var list in lists)
			foreach (var item in list) result.Add(item);
		return result;
	}
}
