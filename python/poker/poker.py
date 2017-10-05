from itertools import groupby

values = '__23456789TJQKA'


def score(hand):
    cards = sorted([(values.index(x[0]), x[1]) for x in hand], reverse=True)
    byValue = sorted([(v, len(list(c))) for v, c in
                      groupby(cards, lambda c: c[0])],
                     reverse=True,
                     key=lambda x: x[1])
    byValueV, byValueLen = zip(*byValue)
    highCard = cards[0][0]
    flush = all(x[1] == cards[0][1] for x in cards)
    straight = all(i == 0 or cards[i - 1][0] == (c[0] % 14) + 1
                   for i, c in enumerate(cards))
    first, secondPair = (byValueLen[0], byValueLen[1] == 2)
    if flush and straight:
        score = 8
    elif first == 4:
        highCard, score = (byValueV[0], 7)
    elif first == 3 and secondPair:
        highCard, score = (byValueV[0], 6)
    elif flush:
        score = 5
    elif straight:
        score = 4
    elif first > 1:
        highCard, score = (byValueV[0],
                           3 if first == 3 else (2 if secondPair else 1))
    else:
        score = 0
    return (score << 4) + highCard


def poker(hands):
    return [[h for _, h in grp] for _, grp in
            groupby(sorted([(score(h), h) for h in hands],
                           reverse=True),
                    key=lambda x: x[0])][0]
