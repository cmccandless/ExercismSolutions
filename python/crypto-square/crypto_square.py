from math import sqrt


def encode(phrase):
    phrase = [x for x in phrase.lower() if x not in " !,.?,'"]
    n = len(phrase)
    if n == 0:
        return ''
    r = int(round(sqrt(n)))
    c = int(round(n / r + 0.5))
    return ' '.join([''.join(x).strip()
                     for x in zip(*[phrase[i:min(i + c, n)] +
                                  [' '] * max(0, i + c - n)
                                  for i in range(0, n, c)])])
