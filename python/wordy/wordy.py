op = {
    'plus': lambda x, y: x + y,
    'minus': lambda x, y: x - y,
    'multiplied': lambda x, y: x * y,
    'divided': lambda x, y: x / y,
}


def noop(x, y):
    raise ValueError()


def calculate(expr):
    s = list(reversed(expr[:-1].split()[2:]))
    r, o = (0, op['plus'])
    while len(s) > 0:
        x = s.pop()
        try:
            r, o = (o(r, int(x)), None)
        except TypeError:
            raise ValueError()
        except ValueError:
            if o is not None:
                raise ValueError()
            o = op.get(x, noop)
            if x == 'multiplied' or x == 'divided':
                s.pop()
    return r
