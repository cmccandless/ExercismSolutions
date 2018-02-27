from functools import reduce
from itertools import zip_longest


def transpose(s):
    return '\n'.join(
        reduce(
            lambda columns, t: [
                a.ljust(t[0] if b else 0) + b
                for a, b in zip_longest(
                    columns,
                    t[1],
                    fillvalue=''
                )
            ],
            enumerate(s.split('\n')),
            []
        )
    )
