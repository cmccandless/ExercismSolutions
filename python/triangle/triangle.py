class Triangle:
    def __init__(self, a, b, c):
        if a + b <= c or b + c <= a or a + c <= b:
            raise TriangleError()
        self.sides = [a, b, c]

    def kind(self):
        a, b, c = self.sides
        if a == b and b == c:
            return 'equilateral'
        elif a == b or b == c or a == c:
            return 'isosceles'
        return 'scalene'


class TriangleError(Exception):
    pass
