class Point(object):
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __repr__(self):
        return 'Point({}:{})'.format(self.x, self.y)

    def __add__(self, other):
        return Point(self.x + other.x, self.y + other.y)

    def __sub__(self, other):
        return Point(self.x - other.x, self.y - other.y)

    def __eq__(self, other):
        return self.x == other.x and self.y == other.y

    def __ne__(self, other):
        return not(self == other)


class WordSearch(object):
    def __init__(self, puzzle):
        self.puzzle = [list(row) for row in puzzle]

    def search(self, word):
        dirs = [Point(i, j)
                for j in range(-1, 2)
                for i in range(-1, 2)
                if i != 0 or j != 0]
        points = [Point(x, y)
                  for y in range(len(self.puzzle))
                  for x in range(len(self.puzzle[y]))
                  if self.puzzle[y][x] == word[0]]
        for p in points:
            for d in dirs:
                _p, i = (p + d, 1)
                while True:
                    try:
                        if word[i] != self.puzzle[_p.y][_p.x]:
                            break
                    except IndexError:
                        break
                    i += 1
                    if i == len(word):
                        return (p, _p)
                    _p += d
