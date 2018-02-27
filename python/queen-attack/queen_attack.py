BOARD_SIZE = 8


class Queen(object):
    def __init__(self, x, y):
        if (
            x < 0 or x >= BOARD_SIZE or
            y < 0 or y >= BOARD_SIZE
        ):
            raise ValueError('invalid board position')
        self.p = (x, y)

    def __eq__(self, other):
        return self.p == other.p

    def can_attack(self, other):
        if self.p == other.p:
            raise ValueError('cannot attack self')
        return (
            self.p[0] == other.p[0] or
            self.p[1] == other.p[1] or
            abs(self.p[0] - other.p[0]) == abs(self.p[1] - other.p[1])
        )
