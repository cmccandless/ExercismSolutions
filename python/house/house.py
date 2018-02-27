words = [
    ('lay in', 'house that Jack built.'),
    ('ate', 'malt'),
    ('killed', 'rat'),
    ('worried', 'cat'),
    ('tossed', 'dog'),
    ('milked', 'cow with the crumpled horn'),
    ('kissed', 'maiden all forlorn'),
    ('married', 'man all tattered and torn'),
    ('woke', 'priest all shaven and shorn'),
    ('kept', 'rooster that crowed in the morn'),
    ('belonged to', 'farmer sowing his corn'),
    ('', 'horse and the hound and the horn')
]


def recite(start, stop):
    def num_gen(start, stop):
        stop -= 0.5
        while start < stop:
            yield start
            start += 0.5
    start -= 1
    return [
        line
        for i in num_gen(start, stop)
        for line in verse(i).split('\n')
    ]


def verse(n, start=True):
    if int(n) != n:
        return ''
    n = int(n)
    verb, noun = words[n]
    return '{} the {}{}'.format('This is' if start else 'that {}'.format(verb),
                                noun, '' if n == 0 else '\n' + verse(n - 1,
                                                                     False))
