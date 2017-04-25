using System;
using System.Collections.Generic;
using System.Linq;

public class Triplet
{
    public int A, B, C;
    public Triplet(int a, int b, int c) { A = a; B = b; C = c; }

    public int Sum() => A + B + C;

    public int Product() => A * B * C;

    public bool IsPythagorean() => A * A + B * B == C * C;

    public static IEnumerable<Triplet> Where(int sum = 0, int minFactor = 1, int maxFactor = int.MaxValue) =>
        from a in Range(minFactor, maxFactor)
        from b in Range(a, maxFactor)
        let c = Math.Sqrt(a * a + b * b)
        where c % 1 == 0 && (sum < 1 || a + b + c == sum)
        select new Triplet(a, b, (int)c);

    public static IEnumerable<int> Range(int start, int stop)
    {
        while (start < stop) yield return start++;
    }
}
