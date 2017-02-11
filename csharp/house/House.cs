using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class House
{
	private static string[][] words = new[] {
		new[] {"","horse and the hound and the horn"},
		new[] {"belonged to","farmer sowing his corn"},
		new[] {"kept","rooster that crowed in the morn"},
		new[] {"woke","priest all shaven and shorn"},
		new[] {"married","man all tattered and torn"},
		new[] {"kissed","maiden all forlorn"},
		new[] {"milked","cow with the crumpled horn"},
		new[] {"tossed","dog"},
		new[] {"worried","cat"},
		new[] {"killed","rat"},
		new[] {"ate","malt"},
		new[] {"lay in","house that Jack built."},
	}.Reverse().ToArray();
	private static string Verse(int i,bool start=true)
	{
		return string.Format("{0} the {1}{2}",start ? "This is" : string.Format("that {0}",words[i][0]),
			words[i][1],i==0? string.Empty : "\n"+Verse(i-1,false));
	}
	public static string Rhyme()
	{
		return string.Join("\n\n", new int[words.Length].Select((_, i) => Verse(i)));
	}
}
