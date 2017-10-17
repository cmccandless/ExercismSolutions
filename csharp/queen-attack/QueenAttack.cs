using System;

public static class QueenAttack
{
    public static (int x, int y) Create(int x, int y)
    {
        if (x < 0 || x > 7 || y < 0 || y > 7) throw new ArgumentOutOfRangeException();
        return (x, y);
    }
    public static bool CanAttack((int x, int y) a, (int x, int y) b)
    {
        if (a.Equals(b)) throw new ArgumentException();
        return a.x == b.x || a.y == b.y || (Math.Abs(a.x - b.x) == Math.Abs(a.y - b.y));
    }
}