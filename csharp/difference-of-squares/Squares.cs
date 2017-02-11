using System;
using System.Collections.Generic;
using System.Linq;

class Squares
{
	private List<int> Numbers;

	public Squares(int n)
	{
		if (n < 0) throw new ArgumentException();
		Numbers = Enumerable.Range(1, n).ToList();
	}

	public int SquareOfSums()
	{
		return (int)Math.Pow(Numbers.Sum(), 2);
	}

	public int SumOfSquares()
	{
		return Numbers.Select(n => n * n).Sum();
	}

	public int DifferenceOfSquares()
	{
		return SquareOfSums() - SumOfSquares();
	}
}
