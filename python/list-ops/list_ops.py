# Please, do not use the built-in python functions like map, reduce, len, etc.
# that solve the same problems and try to solve it yourself instead.


def map_clone(function, xs):
    s = []
    for x in xs:
        append(s, function(x))
    return s


def length(xs):
    count = 0
    for x in xs:
        count += 1
    return count


def filter_clone(function, xs):
    for x in xs:
        if function(x):
            yield x


def reverse(xs):
    s = []
    n = length(xs)
    for i in range(n - 1, -1, -1):
        append(s, xs[i])
    if n > 0 and isinstance(xs, tuple):
        s = tuple(s)
    return s


def append(xs, y):
    xs.insert(length(xs), y)
    return xs


def foldl(function, xs, acc):
    for x in xs:
        acc = function(acc, x)
    return acc


def foldr(function, xs, acc):
    while length(xs) > 0:
        acc = function(xs.pop(), acc)
    return acc


def flat(xs):
    s = []
    for x in xs:
        if isinstance(x, list):
            for y in flat(x):
                append(s, y)
        else:
            append(s, x)
    return s


def concat(xs, ys):
    if ys is not None:
        for y in ys:
            append(xs, y)
    return xs
