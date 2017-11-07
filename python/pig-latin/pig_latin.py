consonents = ['sch', 'squ', 'thr', 'qu', 'th', 'sc', 'sh', 'ch', 'st', 'rh']
consonents.extend('bcdfghjklmnpqrstvwxyz')


def prefix(word):
    if word[:2] not in ['xr', 'yt']:
        for x in consonents:
            if word.startswith(x):
                return (x, word[len(x):])
    return ('', word)


def translate(phrase):
    return ' '.join([x + y + 'ay' for y, x in
                     map(prefix, phrase.split())])
