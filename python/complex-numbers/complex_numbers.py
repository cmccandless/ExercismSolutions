import math


class ComplexNumber(object):
    def __init__(self, real, imaginary):
        self.real = real
        self.imaginary = imaginary

    def __iter__(self):
        return [self.real, self.imaginary].__iter__()

    def add(self, other):
        return ComplexNumber(self.real + other.real,
                             self.imaginary + other.imaginary)

    def mul(self, other):
        a, b = self
        c, d = other
        return ComplexNumber(a * c - b * d, a * d + b * c)

    def sub(self, other):
        return ComplexNumber(self.real - other.real,
                             self.imaginary - other.imaginary)

    def div(self, other):
        a, b = self
        c, d = other
        div = c * c + d * d
        return ComplexNumber((a * c + b * d) / div,
                             (b * c - a * d) / div)

    def abs(self):
        r, i = self
        return math.sqrt(r * r + i * i)

    def conjugate(self):
        return ComplexNumber(self.real, -self.imaginary)

    def exp(self):
        r, i = self
        # Rounding necessary due to rounding error in
        # implementation of sin
        return ComplexNumber(pow(math.e, r) * math.cos(i),
                             round(math.sin(i), 10))
