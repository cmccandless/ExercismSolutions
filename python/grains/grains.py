def on_square(n):
    if n < 1 or n > 64:
        raise ValueError()
    return pow(2, n - 1)


def total_after(n):
    if n < 1 or n > 64:
        raise ValueError()
    return sum([on_square(i) for i in range(1, n + 1)])
