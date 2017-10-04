def bottles(n):
    if n == 0:
        return 'No more bottles'
    elif n == 1:
        return '1 bottle'
    else:
        return '{} bottles'.format(n)


def song(start, end=0):
    return ''.join([verse(i) + '\n' for i in reversed(range(end, start + 1))])


def verse(n):
    if n == 0:
        line2 = 'Go to the store and buy some more, {}'.format(bottles(99))
    else:
        whatToTakeDown = 'it' if n == 1 else 'one', bottles(n - 1).lower()
        line2 = 'Take {} down and pass it around, {}'.format(whatToTakeDown)
    b = bottles(n)
    return ('{} of beer on the wall, '.format(b) +
            '{} of beer.\n{} of beer on the wall.\n').format(b.lower(), line2)
