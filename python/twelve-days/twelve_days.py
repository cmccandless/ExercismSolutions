nth = [
    None,
    'first',
    'second',
    'third',
    'fourth',
    'fifth',
    'sixth',
    'seventh',
    'eighth',
    'ninth',
    'tenth',
    'eleventh',
    'twelfth',
]

gift = [
    None,
    'a Partridge in a Pear Tree',
    'two Turtle Doves',
    'three French Hens',
    'four Calling Birds',
    'five Gold Rings',
    'six Geese-a-Laying',
    'seven Swans-a-Swimming',
    'eight Maids-a-Milking',
    'nine Ladies Dancing',
    'ten Lords-a-Leaping',
    'eleven Pipers Piping',
    'twelve Drummers Drumming',
]


def verse(n):
    words = 'On the {} day of Christmas my true love gave to me, {}.'
    return words.format(nth[n],
                        ', '.join([('and ' if n > 1 and i == 1 else '') +
                                   gift[i]
                                   for i in reversed(range(1, n + 1))]))


def recite(start, end):
    return [verse(i) for i in range(start, end + 1)]
