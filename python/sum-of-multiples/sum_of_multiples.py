def sum_of_multiples(n, factors):
    return sum(set([i for x in factors if x > 0 for i in range(x, n, x)]))
