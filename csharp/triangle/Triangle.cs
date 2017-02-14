using System;

public enum TriangleKind
{
	Equilateral,
	Isosceles,
	Scalene,
}

public class Triangle
{
    private static bool Invalid(decimal a, decimal b, decimal c) =>
            a <= 0 || b <= 0 || c <= 0 ||
            a >= b + c || b >= a + c || c >= a + b; 

    public static TriangleKind Kind(decimal a, decimal b, decimal c)
	{
		if (Invalid(a,b,c)) throw new TriangleException();
        return (a == b && b == c) ? TriangleKind.Equilateral :
            (a == b || b == c || a == c) ? TriangleKind.Isosceles :
            TriangleKind.Scalene;
	}
}

public class TriangleException : Exception
{

}
