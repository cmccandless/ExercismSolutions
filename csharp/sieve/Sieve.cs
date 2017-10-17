using System;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) throw new ArgumentOutOfRangeException();
        var isNotPrime = new bool[limit + 1];
        var primes = new List<int>();
        for (int i = 2; i <= limit; i++)
        {
            if (isNotPrime[i]) continue;
            primes.Add(i);
            for (int j = 2 * i; j <= limit; j += i) isNotPrime[j] = true;
        }
        return primes.ToArray();
    }
}
