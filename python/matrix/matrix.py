class Matrix:
    def __init__(self, str):
        self.rows = [[int(x) for x in line.split(' ')]
                     for line in str.split('\n')]

    def row(self, i):
        return self.rows[i]

    def column(self, i):
        return list(list(zip(*self.rows))[i])
