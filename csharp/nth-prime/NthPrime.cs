using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    public static int Prime(int n)
    {
        if (n < 1) throw new ArgumentOutOfRangeException();
        return Primes().Skip(n - 1).First();
    }

    private static IEnumerable<int> Primes(int startSize = 1024)
    {
        var notPrime = new bool[startSize];
        notPrime[0] = notPrime[1] = true;
        var start = 2;
        while (notPrime.Length < int.MaxValue / 2)
        {
            for (int i = start; i < notPrime.Length; i += i == 2 ? 1 : 2)
            {
                if (notPrime[i]) continue;
                yield return i;
                for (int n = i + i; n < notPrime.Length; n += i) notPrime[n] = true;
            }
            notPrime = notPrime.Expand(out start);
        }
    }

    private static bool[] Expand(this bool[] notPrime, out int start)
    {
        start = notPrime.Length + 1;
        var stop = start - 1;
        var a = new bool[notPrime.Length * 2];
        Array.Copy(notPrime, a, notPrime.Length);
        for (int i = 2; i < start; i += i == 2 ? 1 : 2)
        {
            if (a[i]) continue;
            for (int n = i * (stop / i + 1); n < a.Length; n += i) a[n] = true;
        }
        return a;
    }
}
