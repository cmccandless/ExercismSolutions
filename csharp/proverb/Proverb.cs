using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Proverb
{
	private static string[] words={"nail","shoe","horse","rider","message","battle","kingdom"};
	public static string Line(int n)
	{
		return n<7 ? string.Format("For want of a {0} the {1} was lost.", words[n-1], words[n]) :
			"And all for the want of a horseshoe nail.";
	}
	public static string AllLines()
	{
		return string.Join("\n", new int[7].Select((_,i) => Line(i+1)));
	}
}
