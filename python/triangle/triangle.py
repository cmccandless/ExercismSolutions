def is_equilateral(sides):
    a, b, c = sides
    return valid_triangle(sides) and a == b and b == c


def is_isosceles(sides):
    a, b, c = sides
    return valid_triangle(sides) and (a == b or b == c or a == c)


def is_scalene(sides):
    return valid_triangle(sides) and not is_isosceles(sides)


def valid_triangle(sides):
    a, b, c = sorted(sides)
    return a > 0 and a + b > c
