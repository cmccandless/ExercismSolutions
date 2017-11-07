from itertools import groupby

types = ['11111', '2111', '221', '311', 'S', 'F', '32', '41', 'SF']


def card_suit(card_str):
    return card_str[-1:]


def card_value(card_str):
    return int(card_str[:-1].replace('J', '11')
                            .replace('Q', '12')
                            .replace('K', '13')
                            .replace('A', '14'))


def is_straight(values):
    if len(values) != 5:
        return False
    nums = [5, 4, 3, 2, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2]
    for i in range(len(nums) - 4):
        if all(values[j] == nums[i + j] for j in range(5)):
            return True
    return False


def hand_key(cards):
    flush = len(set(map(card_suit, cards))) == 1
    cards_by_value = [(len(list(grp)), key) for key, grp in
                      groupby(sorted(cards), card_value)]
    cards_by_value_desc = sorted(cards_by_value, reverse=True)
    values = sorted(set(v for _, v in cards_by_value), reverse=True)
    straight = is_straight(values)
    counts = ''.join(str(c) for c, _ in cards_by_value_desc)
    if not (straight or flush):
        _class = types.index(counts)
    else:
        _type = 'S' if straight else ''
        if flush:
            _type += 'F'
        _class = types.index(_type)
    values_str = ''.join('{:02}'.format(k) for n, k in cards_by_value_desc)
    return '{}_{}'.format(_class, values_str)


def poker(hands):
    return list(sorted(groupby(sorted(hands, key=hand_key), hand_key),
                       key=lambda t: t[0],
                       reverse=True)[0][1])
