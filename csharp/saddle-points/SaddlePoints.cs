using System;
using System.Collections.Generic;
using System.Linq;

class SaddlePoints
{
	private int[,] Matrix { get; set; }
	public SaddlePoints(int[,] values)
	{
		Matrix = values;
	}

	public IEnumerable<Tuple<int,int>> Calculate()
	{
		for (int r=0; r <= Matrix.GetUpperBound(0); r++)
		{
			var rowMax = GetRowMax(r);
			for (int c = 0; c <= Matrix.GetUpperBound(1); c++)
			{
				var colMin = GetColMin(c);
				var value = Matrix[r, c];
				if (value == colMin && value == rowMax) yield return Tuple.Create(r, c);
			}
		}
	}

	private int GetRowMax(int r)
	{
		return Enumerable.Range(0, Matrix.GetUpperBound(1)+1).Select(i => Matrix[r, i]).Max();
	}

	private int GetColMin(int c)
	{
		return Enumerable.Range(0, Matrix.GetUpperBound(0)+1).Select(i => Matrix[i, c]).Min();
	}
}
