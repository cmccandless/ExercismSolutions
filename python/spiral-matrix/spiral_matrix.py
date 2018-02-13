def take(iterable, n):
    return [next(iterable) for _ in range(n)]


def count(start, step=1):
    while True:
        yield start
        start += step


def spiral(size, ms=None):
    if size == 0:
        return []
    if ms is None:
        ms = [[size * size]]
    n = len(ms)
    if n == size:
        return ms
    index = ((n % 2) ^ (size % 2)) * -1
    s = ms[index][index] - 1
    if index == 0:
        m = [
            [a] + b
            for a, b in zip(
                count(s, -1),
                ms + [take(count(s - n - 1, -1), n)]
            )
        ]
    else:
        m = (
            [take(count(s - 2 * n), n + 1)] +
            [a + [b] for a, b in zip(ms, count(s - n + 1))]
        )
    return spiral(size, m)
