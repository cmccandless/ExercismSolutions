def bottles(n):
    if n == 0:
        return 'No more bottles'
    elif n == 1:
        return '1 bottle'
    else:
        return '{} bottles'.format(n)


def recite(start, take=1):
    def num_gen(start, count):
        stop = start - count + 0.5
        while start > stop:
            yield start
            start -= 0.5
    return [
        line
        for i in num_gen(start, take)
        for line in verse(i)
    ]


def verse(n):
    if int(n) != n:
        return ['']
    n = int(n)
    if n == 0:
        line2 = 'Go to the store and buy some more, {}'.format(bottles(99))
    else:
        whatToTakeDown = ('it' if n == 1 else 'one', bottles(n - 1).lower())
        line2 = 'Take {} down and pass it around, {}'.format(*whatToTakeDown)
    b = bottles(n)
    return ['{} of beer on the wall, {} of beer.'.format(b, b.lower()),
            '{} of beer on the wall.'.format(line2)]
