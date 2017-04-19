using System;
using System.Linq;

static class Squares
{
    public static int SquareOfSums(int n) => (int)Math.Pow(Enumerable.Range(1, n).Sum(), 2);
    
	public static int SumOfSquares(int n) => Enumerable.Range(1,n).Select(x => x * x).Sum();

    public static int DifferenceOfSquares(int n) => SquareOfSums(n) - SumOfSquares(n);
}
