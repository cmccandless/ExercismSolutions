using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Flattener
{
	public static List<object> Flatten(List<object> list)
	{
		var a = new List<object>();
		var q = new Queue<object>(list);
		while (q.Count > 0)
		{
			var x = q.Dequeue();
			if (x == null) continue;
			if (x is List<object>)
			{
				foreach (var y in x as List<object>) q.Enqueue(y);
			}
			else a.Add(x);
		}
		return a;
	}
}
