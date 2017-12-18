def encode(bytes):
    result = []
    for b in bytes:
        print('For:', b)
        t = []
        while b != 0:
            t.insert(0, b & 0x7f)
            b >>= 7
        for i in range(len(t) - 1):
            t[i] |= 0x80
        if len(t) == 0:
            result.append(0)
        else:
            for x in t:
                result.append(x)
    return result


def decode(bytes):
    if len(bytes) > 0 and bytes[-1] & 0x80 > 0:
        raise ValueError('incomplete sequence')
    result = []
    x = 0
    for b in bytes:
        x = (x << 7) | (b & 0x7f)
        if b & 0x80 == 0:
            result.append(x)
            x = 0
    return result
