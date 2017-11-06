def formatEnc(ch, c):
    if c > 1:
        return '{}{}'.format(c, ch)
    return ch


def encode(plaintext):
    result = ''
    c = 0
    prev = None
    for ch in plaintext:
        if ch != prev:
            if prev is not None:
                result = '{}{}'.format(result, formatEnc(prev, c))
            prev = ch
            c = 1
        else:
            c += 1
    if prev is not None:
        result = '{}{}'.format(result, formatEnc(prev, c))
    return result


def decode(encoded):
    result = ''
    c = 0
    for ch in encoded:
        try:
            d = int(ch)
            c *= 10
            c += d
        except ValueError:
            result = '{}{}'.format(result, ''.join([ch] * (c if c > 0 else 1)))
            c = 0
    return result
