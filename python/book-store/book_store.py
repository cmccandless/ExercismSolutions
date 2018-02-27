from functools import reduce

BASE_COST = 800
discount = [1.0, 1.0, 0.95, 0.9, 0.8, 0.75]


def groupCost(g):
    return len(g) * discount[len(g)]


class Grouping:
    def __init__(self, groups=[set()]):
        self.groups = groups

    def total(self):
        return sum(map(groupCost, self.groups)) * BASE_COST

    def dup(self):
        return Grouping(list(map(set, self.groups)))

    def add(self, b, index=0):
        other = self.dup()
        other.groups.sort(key=lambda g: len(g))
        valid = list(filter(lambda g: b not in g, other.groups))
        if len(valid) == 0:
            other.groups.append(set([b]))
        else:
            valid[index].add(b)
        return other

    def __lt__(self, other):
        return self.total() < other.total()


def step(t, b):
    sm, la = t
    return (min(sm.add(b), la.add(b)), min(sm.add(b, -1), la.add(b, -1)))


def calculate_total(books):
    if len(books) == 0:
        return 0
    start = Grouping().add(books[0])
    return round(min(reduce(step, books[1:], (start, start.dup()))).total())
