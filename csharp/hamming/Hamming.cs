using System;
using System.Linq;

public class Hamming
{
    private static int NotSame<T>(T a, T b) => a.Equals(b) ? 0 : 1;
    public static int Distance(string a, string b) 
    {
        if (a.Length != b.Length) throw new ArgumentException();
        return a.Zip(b, NotSame).Sum();
    }
}
