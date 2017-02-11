using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BracketPush
{
	private static List<char> open = new List<char> { '[','(','{'};
	private static List<char> close = new List<char> { ']',')','}'};
	public static bool Matched(string input)
	{
		if (input.Length == 0) return true;
		var sInput = new Stack<char>(input.ToCharArray().Reverse());
		var sOpen = new Stack<char>();
		var o = sInput.Pop();
		if (close.Contains(o)) return false;
		if (open.Contains(o)) sOpen.Push(o);
		while (sInput.Count > 0)
		{
			var x = sInput.Pop();
			if (open.Contains(x)) sOpen.Push(x);
			else if (close.Contains(x))
			{
				if (sOpen.Count == 0) return false;
				o = sOpen.Pop();
				if (open.IndexOf(o) != close.IndexOf(x)) return false;
			}
		}
		return sOpen.Count==0;
	}
}
