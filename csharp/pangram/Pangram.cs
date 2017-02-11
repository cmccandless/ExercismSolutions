using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Pangram
{
	private static HashSet<char> chars = new HashSet<char>(Enumerable.Range((int)'a', 26).Select(x => (char)x));
	public static bool IsPangram(string str)
	{
		return new HashSet<char>(str.ToLower().ToCharArray()).Intersect(chars).Count()==chars.Count;
	}
}
