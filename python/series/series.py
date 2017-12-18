def slices(series, i):
    if i == 0 or i > len(series):
        raise ValueError(
            'slice size must be in interval [1,{}]'.format(len(series))
        )
    ints = [int(x) for x in series]
    return [ints[x:i + x] for x in range(len(series) - i + 1)]
