from functools import reduce

segments = {
    (0, 1): ('_', set('02356789')),
    (1, 0): ('|', set('045689')),
    (1, 1): ('_', set('2345689')),
    (1, 2): ('|', set('01234789')),
    (2, 0): ('|', set('0268')),
    (2, 1): ('_', set('0235689')),
    (2, 2): ('|', set('013456789')),
}
DIGITS = set('0123456789')


def grid(nums):
    digitPairs = [(n, int(n)) for n in nums]
    return [''.join([''.join([' ' if q is None or n not in q[1] else q[0]
                              for q in [segments.get((y, x))
                                        for x in range(3)]])
                     for n, i in digitPairs])
            for y in range(3)] + ['   ' * len(nums)]


def intersect(a, b):
    return set([x for x in a if x in b])


def subtract(a, b):
    return set([x for x in a if x not in b])


def number(nums):
    if len(nums) < 4:
        raise ValueError()
    for line in nums:
        if len(line) != len(nums[0]):
            raise ValueError()

    def reducer(a, b):
        return intersect(a, b[0] if b[1] else subtract(a, b[0]))

    def mergeTuples(t):
        return tuple(list(t[0]) + list(t[1]))

    def segmentCheck(n, t):
        y, x, c, s = t
        return (s, n[y][x] == c)
    return ''.join(['?' if b or len(ns) == 0 else ns.pop()
                    for ns, b in
                    [(reduce(reducer,
                             map(lambda t: segmentCheck(n, t),
                                 map(mergeTuples, segments.items())),
                             DIGITS),
                      set(n[-1]) != set(' '))
                     for n in
                     [[x[i:i + 3] for x in nums]
                      for i in range(0, len(nums[0]), 3)]]])
