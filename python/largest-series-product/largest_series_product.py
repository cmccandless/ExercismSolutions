from functools import reduce


def largest_product(s, n):
    if n < 0:
        raise ValueError('length must be 0 or greater')
    elif n > len(s):
        raise ValueError('cannot have length greater than series length')
    if s == '' or n == 0:
        return 1

    def product(slice):
        return reduce(lambda x, y: x * y, map(int, slice))
    return sorted([product(s[i:i + n]) for i in range(0, len(s) - n + 1)])[-1]
