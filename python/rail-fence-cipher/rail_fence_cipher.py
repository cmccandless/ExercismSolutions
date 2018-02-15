def encode(str, n):
    rails = [[] for _ in range(n)]
    cap = 2 * n - 2
    for i, ch in enumerate(str):
        index = i % cap
        if index >= n:
            index = 2 * n - index - 2
        rails[index].append(ch)
    return ''.join(ch for r in rails for ch in r)


def decode(str, n):
    railCounts = [0] * n
    cap = 2 * n - 2
    for i in range(len(str)):
        index = i % cap
        if index >= n:
            index = 2 * n - index - 2
        railCounts[index] += 1
    q = list(str)
    rails = [
        [q.pop(0) for _ in range(r)]
        for r in railCounts
    ]
    decoded = []
    d_append = decoded.append
    for i in range(len(str)):
        index = i % cap
        if index >= n:
            index = 2 * n - index - 2
        d_append(rails[index].pop(0))
    return ''.join(decoded)
