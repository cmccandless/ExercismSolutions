def encode(str, n):
    rails, r, d = ([''] * n, 0, 1)
    for i, c in enumerate(str):
        rails[r] = ''.join([rails[r], c])
        r += d
        if r < 0:
            d = r = 1
        elif r == n:
            d, r = (-1, n - 2)
    return ''.join(rails)


def decode(str, n):
    s, rails, r, d = (len(str), [0] * n, 0, 1)
    for i, c in enumerate(str):
        rails[r] += 1
        r += d
        if r < 0:
            d = r = 1
        elif r == n:
            d, r = (-1, n - 2)
    for r in range(len(rails)):
        rails[r], str = (list(reversed(str[:rails[r]])), str[rails[r]:])
    result, r, d = ('', 0, 1)
    for _ in range(s):
        result = ''.join([result, rails[r].pop()])
        r += d
        if r < 0:
            d = r = 1
        elif r == n:
            d, r = (-1, n - 2)
    return result
