from math import sqrt


def dims(n):
    r = sqrt(n)
    while r % 1 != 0:
        n += 1
        r = sqrt(n)
    return (int(r), int(n / r))


def encode(phrase):
    phrase = [x for x in phrase.lower() if x not in " !,.?,'@%"]
    n = len(phrase)
    if n == 0:
        return ''
    r, c = dims(n)
    return ' '.join([''.join(x)
                     for x in zip(*[phrase[i:min(i + c, n)] +
                                  [' '] * max(0, i + c - n)
                                  for i in range(0, n, c)])])
