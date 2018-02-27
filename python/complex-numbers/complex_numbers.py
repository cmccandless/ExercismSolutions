import math
ERR = 15


class ComplexNumber(object):
    def __init__(self, real, imaginary):
        self.real = real
        self.imaginary = imaginary

    def __iter__(self):
        return [self.real, self.imaginary].__iter__()

    def __add__(self, other):
        return ComplexNumber(self.real + other.real,
                             self.imaginary + other.imaginary)

    def __mul__(self, other):
        a, b = self
        c, d = other
        return ComplexNumber(a * c - b * d, a * d + b * c)

    def __sub__(self, other):
        return ComplexNumber(self.real - other.real,
                             self.imaginary - other.imaginary)

    def __truediv__(self, other):
        a, b = self
        c, d = other
        div = c * c + d * d
        return ComplexNumber((a * c + b * d) / div,
                             (b * c - a * d) / div)

    def __abs__(self):
        r, i = self
        return math.sqrt(r * r + i * i)

    def conjugate(self):
        return ComplexNumber(self.real, -self.imaginary)

    def exp(self):
        r, i = self
        a = math.e ** r
        r = round(math.cos(i) * a, ERR)
        i = round(math.sin(i) * a, ERR)
        return ComplexNumber(r, i)

    def __eq__(self, other):
        return tuple(self) == tuple(other)

    def __repr__(self):
        return '{} + {}i'.format(*tuple(self))
