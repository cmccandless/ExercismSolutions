def validate_factors(min_factor, max_factor):
    if min_factor > max_factor:
        raise ValueError('min_factor cannot be greater than max_factor')


def smallest_palindrome(max_factor, min_factor=0):
    validate_factors(min_factor, max_factor)
    for m in range(min_factor, max_factor + 1):
        for n in range(min_factor, m + 1):
            p = m * n
            s = str(p)
            if s == s[::-1]:
                return (p, {(m, n)})
    raise ValueError('no palindrome products in range')


def largest_palindrome(max_factor, min_factor=0):
    validate_factors(min_factor, max_factor)
    best_factors = (min_factor, min_factor)
    best = (min_factor ** 2, {best_factors})
    for m in reversed(range(min_factor, max_factor + 1)):
        for n in reversed(range(min_factor, m + 1)):
            p = m * n
            s = str(p)
            if s == s[::-1]:
                if best[0] < p:
                    best = (p, {(m, n)})
                elif best[0] == p:
                    best[1].add((m, n))
                continue
    if str(best[0]) == str(best[0])[::-1]:
        return best
    raise ValueError('no palindrome products in range')
