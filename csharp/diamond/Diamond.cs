using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Diamond
{
	public static string Make(char ch)
	{
		var result = new List<string>();
		for (char x='A';x<=ch;x++)
		{
			for (int i = 0; i < result.Count; i++) result[i] = ' ' + result[i] + ' ';
			if (x == 'A') result.Add("A");
			else result.Add(x + string.Join(string.Empty,Enumerable.Repeat(" ",2*result.Count-1)) + x);
		}
		return string.Join("\n",result.Concat(result.ToArray().Reverse().Skip(1)));
	}
}
