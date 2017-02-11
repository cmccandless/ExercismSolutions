using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ParallelLetterFrequency
{
	public static Dictionary<char, int> Calculate(IEnumerable<string> lines)
	{
		return (from line in lines.AsParallel()
				from letter in line.ToLower()
				where char.IsLetter(letter)
				group letter by letter into grp
				select grp).ToDictionary(g => g.Key, g => g.Count());
	}
}
