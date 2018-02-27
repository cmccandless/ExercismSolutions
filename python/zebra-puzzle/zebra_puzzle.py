from itertools import permutations


def drinks_water():
    return solution()[0]


def owns_zebra():
    return solution()[1]


def solution():
    nHouses = 5  # Constraint 1
    perms = list(permutations(range(nHouses)))
    first, second, middle, fourth, last = list(range(5))
    for (eng, jap, nor, span, ukr) in perms:
        if nor is not first:  # Constraint 10
            continue
        for (red, blue, green, ivory, yellow) in perms:
            if eng is not red:  # Constraint 2
                continue
            if green is not ivory + 1:  # Constraint 6
                continue
            if blue is not second:  # Constraint 15+10
                continue
            for (ches, kools, lucky, parl, old) in perms:
                if yellow is not kools:  # Constraint 8
                    continue
                if jap is not parl:  # Constraint 14
                    continue
                for (coffee, milk, oj, tea, water) in perms:
                    if coffee is not green:  # Constraint 4
                        continue
                    if tea is not ukr:  # Constraint 5
                        continue
                    if milk is not middle:  # Constraint 9
                        continue
                    if oj is not lucky:  # Constraint 13
                        continue
                    for (dog, horse, fox, snails, zebra) in perms:
                        if span is not dog:  # Constraint 3
                            continue
                        if snails is not old:  # Constraint 7
                            continue
                        if ches - fox not in {1, -1}:  # Constraint 11
                            continue
                        if kools - horse not in {1, -1}:  # Constraint 12
                            continue
                        t = [{eng: 'Englishman',
                              jap: 'Japanese',
                              nor: 'Norwegian',
                              span: 'Spaniard',
                              ukr: 'Ukrainian'}[x] for x in (water, zebra)]
                        return t
