nth = 0
gen = None
_n = 120000


def nth_prime(n):
    if n < 1:
        raise ValueError('n must be 1 or greater')
    global gen, nth, _n
    n -= 1
    if gen is None or nth > n:
        gen = primes(_n)
        nth = 0
    try:
        for _ in range(n - nth):
            next(gen)
            nth += 1
        nth += 1
        return next(gen)
    except StopIteration:
        _n *= 2
        nth = 0
        gen = primes(_n)
        return nth_prime(n + 1)


def primes(n=_n):
    print('primes')
    np = [False] * n
    np[0] = np[1] = True
    i = 2
    while i < n:
        if not np[i]:
            yield i
            for x in range(2 * i, n, i):
                np[x] = True
        i += 1
    raise StopIteration()
