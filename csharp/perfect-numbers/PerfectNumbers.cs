using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification { Deficient, Perfect, Abundant }

public static class PerfectNumbers
{
    public static Classification Classify(int n) => ClassifyDifference(n.Factors().Sum() - n);

    private static Classification ClassifyDifference(int d) => 
        d < 0 ? Classification.Deficient : 
        d == 0 ? Classification.Perfect : 
        Classification.Abundant;

    private static IEnumerable<int> Factors(this int n)
    {
        if (n < 1) throw new ArgumentOutOfRangeException();
        if (n == 1) yield break;
        yield return 1;
        var limit = Math.Sqrt(n);
        for (int i = 2; i <= limit; i++)
        {
            var q = n / (double)i;
            if (q % 1 == 0)
            {
                yield return i;
                if (i < q) yield return (int)q;
            }
        }
    }
}
