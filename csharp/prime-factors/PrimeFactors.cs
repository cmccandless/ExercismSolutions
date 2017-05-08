using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    private static IEnumerable<int> Primes()
    {
        var notPrime = new bool[1024];
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
            start = notPrime.Length + 1;
            var a = new bool[notPrime.Length * 2];
            Array.Copy(notPrime, a, notPrime.Length);
            notPrime = a;
            for (int i = 2; i < start; i += i == 2 ? 1 : 2)
            {
                if (notPrime[i]) continue;
                for (int n = i * ((start - 1) / i + 1); n < notPrime.Length; n += i) notPrime[n] = true;
            }
        }
    }

    public static int[] For(long i)
    {
        var result = new List<int>();
        if (i <= 1) return new int[0];
        foreach (var prime in Primes())
        {
            while (i % prime == 0)
            {
                i /= prime;
                result.Add(prime);
            }
            if (i == 1) break;
        }
        return result.ToArray();
    }
}
