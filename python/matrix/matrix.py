class Matrix:
    def __init__(self, str):
        self.rows = [[int(x) for x in line.split(' ')]
                     for line in str.split('\n')]
        self.columns = [[self.rows[r][c]
                         for r in range(len(self.rows))]
                        for c in range(len(self.rows[0]))]
