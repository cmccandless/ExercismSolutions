from __future__ import division
import fractions


class Rational(object):
    def __init__(self, numer, denom):
        gcd = fractions.gcd(numer, denom)
        self.numer = numer // gcd
        self.denom = denom // gcd

    def __eq__(self, other):
        return self.numer == other.numer and self.denom == other.denom

    def __repr__(self):
        return '{}/{}'.format(self.numer, self.denom)

    def __add__(self, other):
        return Rational(
            self.numer * other.denom + other.numer * self.denom,
            self.denom * other.denom
        )

    def __sub__(self, other):
        return Rational(
            self.numer * other.denom - other.numer * self.denom,
            self.denom * other.denom
        )

    def __mul__(self, other):
        return Rational(
            self.numer * other.numer,
            self.denom * other.denom
        )

    def __truediv__(self, other):
        return Rational(
            self.numer * other.denom,
            self.denom * other.numer
        )

    def __abs__(self):
        if self.numer < 0:
            return Rational(-self.numer, self.denom)
        return self

    def __pow__(self, power):
        return Rational(
            self.numer ** power,
            self.denom ** power
        )

    def __rpow__(self, base):
        return (base ** (1.0 / self.denom)) ** self.numer
