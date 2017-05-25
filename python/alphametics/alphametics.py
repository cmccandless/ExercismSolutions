## Runtime: 28.07s
def solve(expr, dict = None, invalidZero = None):
    if dict is None: dict = {}
    if invalidZero is None:
        invalidZero = set(w[0] for w in expr.split(' ') if '+' != w and '==' != w)
    letters = set(c for c in expr if c.isalpha())
    attempted = None
    for ch in letters:
        if ch not in dict:
            attempted = ch
            break
    if attempted is None:
        parts = expr.split(' == ')
        if dict[parts[1][0]] == 0: return None
        equal = int(''.join(str(dict[ch]) for ch in parts[1]))
        terms = parts[0].split(' + ')
        if any(dict[t[0]] == 0 for t in terms): return None
        termSum = sum(int(''.join(str(dict[ch]) for ch in w)) for w in terms)
        if equal == termSum: return dict 
    else:
        values = set(x for y,x in dict.items())
        for x in range(1 if attempted in invalidZero else 0, 10):
            if x in values: continue
            dict[attempted] = x
            result = solve(expr, dict, invalidZero)
            if result is not None: return dict
        del dict[attempted]
    if len(dict) == 0: raise Exception()
    return None
