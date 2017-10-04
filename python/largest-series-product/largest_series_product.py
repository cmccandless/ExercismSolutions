from functools import reduce


def largest_product(s, n):
    if n < 0 or (s == '' and n > 0) or n > len(s):
        raise ValueError()
    if s == '' or n == 0:
        return 1

    def product(slice):
        return reduce(lambda x, y: x * y, map(int, slice))
    return sorted([product(s[i:i + n]) for i in range(0, len(s) - n + 1)])[-1]
