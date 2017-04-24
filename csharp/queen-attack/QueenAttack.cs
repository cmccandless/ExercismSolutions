using System;

public class Queen
{
    public int X { get; set; }
    public int Y { get; set; }
    public Queen(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override bool Equals(object obj) => Equals(obj as Queen);
    public override int GetHashCode() => base.GetHashCode();
    public bool Equals(Queen other) => X.Equals(other?.X) && Y.Equals(other.Y);
}

public class Queens
{
    public static bool CanAttack(Queen a, Queen b)
    {
        if (a.Equals(b)) throw new ArgumentException();
        return a.X == b.X || a.Y == b.Y || (Math.Abs(a.X - b.X) == Math.Abs(a.Y - b.Y));
    }
}
