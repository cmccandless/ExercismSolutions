from math import sqrt


def classify(n):
    if n < 1:
        raise ValueError('number must be greater than 0')
    s, f = (0, factors(n))
    try:
        while s <= n:
            s += int(next(f))
    except StopIteration:
        pass
    print(s, n)
    if s < n:
        return 'deficient'
    if s == n:
        return 'perfect'
    # if s > n:
    return 'abundant'


def factors(n):
    if n > 1:
        yield 1
        for i in range(2, int(sqrt(n)) + 1):
            if n % i == 0:
                yield i
                q = n / i
                if i != q:
                    yield n / i
