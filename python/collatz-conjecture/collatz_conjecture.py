def collatz_steps(n):
    if n < 1:
        raise ValueError('n must be positive')
    steps = 0
    while n != 1:
        n = n / 2 if n % 2 == 0 else 3 * n + 1
        steps += 1
    return steps
