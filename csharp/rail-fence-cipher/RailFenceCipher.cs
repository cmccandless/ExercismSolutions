using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RailFenceCipher
	{
	private readonly int nRails;
	public RailFenceCipher(int nRails)
	{
		this.nRails = nRails;
	}
	public string Encode(string str)
	{
		var rails = (from _ in Enumerable.Range(0,nRails) select string.Empty).ToArray();
		var r = 0;
		var d = 1;
		for (int i = 0; i < str.Length;i++ )
		{
			rails[r] += str[i];
			r += d;
			if (r<0) d = r = 1;
			else if (r==nRails)
			{
				d = -1;
				r = nRails - 2;
			}
		}
		return string.Join(string.Empty, rails);
	}
	public string Decode(string str)
	{
		var s = str.Length;
		var railCounts = new int[nRails];
		var r = 0;
		var d = 1;
		for (int i=0;i<s;i++)
		{
			railCounts[r]++;
			r += d;
			if (r < 0) d = r = 1;
			else if (r == nRails)
			{
				d = -1;
				r = nRails - 2;
			}
		}
		var rails = new Queue<char>[nRails];
		var start = 0;
		for (int i=0;i<nRails;i++)
		{
			var n = railCounts[i];
			rails[i] = new Queue<char>(str.Substring(start,n));
			start += n;
		}
		var result = string.Empty;
		r = 0;
		d = 1;
		for (int i=0;i<s;i++)
		{
			result += rails[r].Dequeue();
			r += d;
			if (r < 0) d = r = 1;
			else if (r == nRails)
			{
				d = -1;
				r = nRails - 2;
			}
		}
		return result;
	}
}
