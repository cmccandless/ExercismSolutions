class CircularBuffer:
    def __init__(self, size):
        self.buf = [None] * size
        self.posW = 0
        self.posR = 0
        self.len = 0

    def __len__(self):
        return self.len

    def _incR(self):
        self.posR = (self.posR + 1) % len(self.buf)

    def _incW(self):
        self.posW = (self.posW + 1) % len(self.buf)

    def write(self, c):
        if len(self) == len(self.buf):
            raise BufferFullException()
        self.buf[self.posW] = c
        self._incW()
        self.len += 1

    def read(self):
        if len(self) == 0:
            raise BufferEmptyException()
        c = self.buf[self.posR]
        self._incR()
        self.len -= 1
        return c

    def overwrite(self, c):
        if len(self) == len(self.buf):
            self.buf[self.posR] = c
            self._incR()
        else:
            self.write(c)

    def clear(self):
        self.len = 0
        self.posW = self.posR = 0


class BufferFullException(Exception):
    pass


class BufferEmptyException(Exception):
    pass
