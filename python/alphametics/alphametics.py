## Runtime: 28.07s
def solve(expr, mappings=None, invalidZero=None):
    if mappings is None:
        mappings = {}
    if invalidZero is None:
        invalidZero = set(w[0] for w in expr.split(' ')
                          if '+' != w and '==' != w)
    letters = set(c for c in expr if c.isalpha())
    attempted = None
    for ch in letters:
        if ch not in mappings:
            attempted = ch
            break
    if attempted is None:
        parts = expr.split(' == ')
        if mappings[parts[1][0]] == 0:
            return None
        equal = int(''.join(str(mappings[ch]) for ch in parts[1]))
        terms = parts[0].split(' + ')
        if any(mappings[t[0]] == 0 for t in terms):
            return None
        termSum = sum(int(''.join(str(mappings[ch]) for ch in w))
                      for w in terms)
        if equal == termSum:
            return mappings
    else:
        values = set(x for y, x in mappings.items())
        for x in range(1 if attempted in invalidZero else 0, 10):
            if x in values:
                continue
            mappings[attempted] = x
            result = solve(expr, mappings, invalidZero)
            if result is not None:
                return mappings
        del mappings[attempted]
    if len(mappings) == 0:
        raise Exception()
    return None
