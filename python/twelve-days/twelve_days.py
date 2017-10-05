nth = {
    1: 'first',
    2: 'second',
    3: 'third',
    4: 'fourth',
    5: 'fifth',
    6: 'sixth',
    7: 'seventh',
    8: 'eighth',
    9: 'ninth',
    10: 'tenth',
    11: 'eleventh',
    12: 'twelfth',
}

gift = {
    1: 'a Partridge in a Pear Tree',
    2: 'two Turtle Doves',
    3: 'three French Hens',
    4: 'four Calling Birds',
    5: 'five Gold Rings',
    6: 'six Geese-a-Laying',
    7: 'seven Swans-a-Swimming',
    8: 'eight Maids-a-Milking',
    9: 'nine Ladies Dancing',
    10: 'ten Lords-a-Leaping',
    11: 'eleven Pipers Piping',
    12: 'twelve Drummers Drumming',
}


def sing():
    return verses(1, 12)


def verse(n):
    words = 'On the {} day of Christmas my true love gave to me, {}.\n'
    return words.format(nth[n],
                        ', '.join([('and ' if n > 1 and i == 1 else '') +
                                   gift[i]
                                   for i in reversed(range(1, n + 1))]))


def verses(start, end):
    return ''.join(verse(i) + '\n' for i in range(start, end + 1))
