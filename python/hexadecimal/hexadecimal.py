_0, _9, a, f = map(ord, '09af')


def hexa(s):
    s = list(map(ord, s.lower()))
    for o in s:
        if o < _0 or (o > _9 and o < a) or o > f:
            raise ValueError('digit must be 0-f')
    return sum(pow(16, i) * (o - _0 if o <= _9 and o >= _0 else o - a + 10)
               for i, o in enumerate(reversed(s)))
