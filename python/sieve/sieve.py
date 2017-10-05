def sieve(n):
    isPrime = [True for _ in range(n + 1)]
    isPrime[0] = isPrime[1] = False
    for i in range(2, n):
        if isPrime[i]:
            for x in range(2 * i, n + 1, i):
                isPrime[x] = False
    return [x for x in range(n + 1) if isPrime[x]]
