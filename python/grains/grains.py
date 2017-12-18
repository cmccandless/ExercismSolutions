def validate_square(n):
    if n < 1:
        raise ValueError('square must be 1 or greater')
    elif n > 64:
        raise ValueError('square must be 64 or less')


def on_square(n):
    validate_square(n)
    return pow(2, n - 1)


def total_after(n):
    validate_square(n)
    return sum([on_square(i) for i in range(1, n + 1)])
