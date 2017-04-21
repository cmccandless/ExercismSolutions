public class Grains
{
    public static ulong Square(int n) => (ulong)1 << (n - 1);
    public static ulong Total() => ulong.MaxValue;
}
