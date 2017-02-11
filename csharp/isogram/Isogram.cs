using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Isogram
{
	public static bool IsIsogram(string input)
	{
		var a = input.ToLower().ToCharArray()
			.Where(c => !"- ".Contains(c));
		return new HashSet<char>(a).Count == a.Count();
	}
}
