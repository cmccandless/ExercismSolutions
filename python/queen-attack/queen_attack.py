BOARD_SIZE = 8


def validate(w, b):
    if w == b:
        raise ValueError()
    wy, wx = w
    by, bx = b
    s = sorted([wy, wx, by, bx])
    if s[0] < 0 or s[3] >= BOARD_SIZE:
        raise ValueError()
    return True


def board(w, b):
    validate(w, b)
    return [''.join(['W' if (y, x) == w else ('B' if (y, x) == b else '_')
                     for x in range(BOARD_SIZE)])
            for y in range(BOARD_SIZE)]


def can_attack(w, b):
    validate(w, b)
    return w[0] == b[0] or w[1] == b[1] or abs(w[0] - b[0]) == abs(w[1] - b[1])
