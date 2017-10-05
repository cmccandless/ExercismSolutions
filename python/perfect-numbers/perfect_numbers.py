from math import sqrt, floor


def is_perfect(n):
    s, f = (0, factors(n))
    try:
        while s <= n:
            s += next(f)
    except StopIteration:
        pass
    return s == n


def factors(n):
    yield 1
    for i in range(2, int(sqrt(n)) + 1):
        if n % i == 0:
            yield i
            yield n / i
