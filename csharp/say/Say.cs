using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.say
{
	public static class Say
	{
		private static string[] digits = new[] {
			string.Empty, "one", "two", "three", "four" ,"five", "six", "seven", 
			"eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", 
			"fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
		private static string[] tens = new[] {
			string.Empty, "ten", "twenty", "thirty", "forty", 
			"fifty", "sixty", "seventy", "eighty", "ninety" };
		private static Dictionary<long, string[]> labels = new Dictionary<long, string[]>{
			{1000000000,	new[]{" "," billion"}},
			{1000000,		new[]{" "," million"}},
			{1000,			new[]{" "," thousand"}},
			{100,			new[]{" "," hundred"}},
			{10,			new[]{"-",string.Empty}},
		};
		private static long[] values = labels.Keys.ToArray();
		public static string InEnglish(long n, bool top = true)
		{
			if (n < 0 || n > 999999999999L) throw new Exception();
			if (top && n == 0) return "zero";
			if (n < 20) return digits[n];
			for (int i = 0; i < labels.Count; i++)
			{
				var value = values[i];
				var separator = labels[value][0];
				var label = labels[value][1];
				if (n >= value)
				{
					var div = n/value;
					var _base = string.Format("{0}{1}",
						value > 10 ? InEnglish(div,false) : tens[(int)div],
						label);
					var mod = n % value;
					if (mod == 0) return _base;
					return string.Format("{0}{1}{2}", _base, separator, InEnglish(mod, false));
				}
			}
			return string.Empty;
		}
	}
}
