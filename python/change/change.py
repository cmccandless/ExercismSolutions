def find_minimum_coins(total_change, coins):
    if total_change < 0 or any(x < 1 for x in coins):
        raise ValueError('no possible solution')
    m = [None] * (total_change + 1)
    m[0] = []
    for c in range(len(coins)):
        for t in range(1, len(m)):
            if coins[c] == t:
                m[t] = [coins[c]]
                continue
            for t2 in range(1, t):
                if (coins[c] + t2 == t and m[t2] is not None and
                   (m[t] is None or len(m[t2]) + 1 < len(m[t]))):
                    m[t] = m[t2] + [coins[c]]
    if m[-1] is None:
        raise ValueError('no possible solution')
    return m[-1]
