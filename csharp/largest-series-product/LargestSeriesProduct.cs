using System;
using System.Linq;

class LargestSeriesProduct
	{
		private int[] Digits { get; set; }
		public LargestSeriesProduct(string digits)
		{
			Digits = digits.Select(ch => (int)ch - '0').ToArray();
		}

		public int GetLargestProduct(int seriesLength)
		{
			if (seriesLength > Digits.Length) throw new ArgumentException();
			return (from i in Enumerable.Range(0,Digits.Length - seriesLength + 1)
					select Digits.Skip(i).Take(seriesLength).Aggregate(1,(x,y)=>x*y))
					.Max();
		}
	}
