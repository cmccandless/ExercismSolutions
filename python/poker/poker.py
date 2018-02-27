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
    ret = False
    if len(values) == 5:
        # Ace ends straight
        if values == [14, 5, 4, 3, 2]:
            ret = True
        else:
            nums = [14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 14]
            for i in range(len(nums) - 4):
                if all(values[j] == nums[i + j] for j in range(5)):
                    ret = True
                    break
    return ret


def hand_key(hand):
    cards = hand.split(' ')
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
    if values == [14, 5, 4, 3, 2]:
        values_str = ''.join(map('{:02}'.format, range(5, 0, -1)))
    else:
        values_str = ''.join('{:02}'.format(k) for n, k in cards_by_value_desc)
    key = '{}_{}'.format(_class, values_str)
    return key


def safe_groupby(iterable, key=None):
    return (
        (k, list(g))  # Cast to list to allow repeated access
        for k, g in groupby(iterable, key=key)
    )


def best_hands(hands):
    return [
        hand
        for key, hand in max(
            safe_groupby(
                sorted(
                    ((hand_key(h), h) for h in hands),
                    key=lambda t: t[0]
                ),
                key=lambda t: t[0]
            )
        )[1]
    ]
