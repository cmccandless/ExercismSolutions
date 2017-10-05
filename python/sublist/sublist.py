SUBLIST = 0
SUPERLIST = 1
EQUAL = 2
UNEQUAL = 3


def check_lists(s, a, checkSuper=True):
    m, n = (len(s), len(a))
    smaller, larger = (s, a)
    if m == n:
        result = EQUAL
    elif m < n:
        result = SUBLIST
    else:
        m, n = (n, m)
        smaller, larger = (a, s)
        result = SUPERLIST
    if m == 0:
        return result
    for i in range(n - m + 1):
        if larger[i:i + m] == smaller:
            return result
    return UNEQUAL
