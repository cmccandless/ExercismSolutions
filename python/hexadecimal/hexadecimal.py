_0 = ord('0')
_9 = ord('9')
a = ord('a')
f = ord('f')


def hexa(s):
    s = list(map(ord, s.lower()))
    for o in s:
        if o < _0 or (o > _9 and o < a) or o > f:
            raise ValueError()
    return sum(pow(16, i) * (o - _0 if o <= _9 and o >= _0 else o - a + 10)
               for i, o in enumerate(reversed(s)))
