def smallest_palindrome(max_factor, min_factor=0):
    for m in range(min_factor, max_factor + 1):
        for n in range(min_factor, m + 1):
            p = m * n
            s = str(p)
            if s == s[::-1]:
                return (p, {m, n})
    return (0, {0})


def largest_palindrome(max_factor, min_factor=0):
    best = (min_factor * min_factor, {min_factor})
    for m in reversed(range(min_factor, max_factor + 1)):
        for n in reversed(range(min_factor, m + 1)):
            p = m * n
            s = str(p)
            if s == s[::-1]:
                if best[0] < p:
                    best = (p, {m, n})
                continue
    return best
