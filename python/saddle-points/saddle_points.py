def saddle_points(m):
    if len(m) == 0:
        return set()
    if any(len(m[0]) != len(m[i]) for i in range(1, len(m))):
        raise ValueError('irregular matrix')
    rowMaxs = [sorted(r, reverse=True)[0] for r in m]
    colMins = [sorted(c)[0] for c in
               [[m[r][c] for r in
                range(len(m))] for c in
                range(len(m[0]))]]
    return set([(x, y) for x in
                range(len(m)) for y, v in
                enumerate(m[x])
                if rowMaxs[x] == v and colMins[y] == v])
