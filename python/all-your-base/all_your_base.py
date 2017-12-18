from functools import reduce


def todecimal(ibase, digits):
    if digits:
        return reduce(lambda x, y: x * ibase + y, digits)
    return 0


def fromdecimal(x, obase):
    result = []
    while x > 0:
        x, r = divmod(x, obase)
        result.insert(0, r)
    return result


def rebase(ibase, digits, obase):
    if ibase < 2:
        raise ValueError('input base must be 2 or greater')
    elif obase < 2:
        raise ValueError('output base must be 2 or greater')
    for d in digits:
        if d < 0 or d >= ibase:
            raise ValueError(
                'digit "{}" is invalid for base {}'.format(d, ibase)
            )
    return fromdecimal(todecimal(ibase, digits), obase)
