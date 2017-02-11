using System;

public enum TriangleKind
{
	Equilateral,
	Isosceles,
	Scalene,
}

public class Triangle
{
	public static TriangleKind Kind(decimal a, decimal b, decimal c)
	{
		if ((a == 0 && b == 0 && c == 0) ||
			a < 0 || b < 0 || c < 0 ||
			a >= b + c || b >= a + c || c >= a + b)
			throw new TriangleException();

		if (a == b && b == c) return TriangleKind.Equilateral;

		if (a == b || b == c || a == c) return TriangleKind.Isosceles;

		return TriangleKind.Scalene;
	}
}

public class TriangleException : Exception
{

}
