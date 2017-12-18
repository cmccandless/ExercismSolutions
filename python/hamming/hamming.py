def distance(x, y):
    if len(x) != len(y):
        raise ValueError('strings must be same length')
    return sum(x[i] != y[i] for i in range(len(x)))
