using System;

class Queen
{
	public int X { get; set; }
	public int Y { get; set; }
	public Queen(int x, int y)
	{
		X = x;
		Y = y;
	}
}
class Queens
{
	private Queen A { get; set; }
	private Queen B { get; set; }
	public Queens(Queen a, Queen b)
	{
		A = a;
		B = b;
		if (A.X == B.X && A.Y == B.Y) throw new ArgumentException();
	}
	public bool CanAttack()
	{
		return A.X == B.X || A.Y == B.Y || (Math.Abs(A.X - B.X) == Math.Abs(A.Y - B.Y));
	}
}
