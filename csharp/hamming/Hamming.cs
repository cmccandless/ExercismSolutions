using System.Linq;

public class Hamming
{
    private static int NotSame<T>(T a, T b) => a.Equals(b) ? 0 : 1;
    public static int Compute(string a, string b) => a.Zip(b, NotSame).Sum();
}
