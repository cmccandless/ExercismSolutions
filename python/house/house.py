words=[
    ('lay in','house that Jack built.'),
    ('ate','malt'),
    ('killed','rat'),
    ('worried','cat'),
    ('tossed','dog'),
    ('milked','cow with the crumpled horn'),
    ('kissed','maiden all forlorn'),
    ('married','man all tattered and torn'),
    ('woke','priest all shaven and shorn'),
    ('kept','rooster that crowed in the morn'),
    ('belonged to','farmer sowing his corn'),
    ('','horse and the hound and the horn')
]

def rhyme():
    return '\n\n'.join(map(verse,range(len(words))))
    
def verse(n,start=True):
    verb,noun=words[n]
    return '{} the {}{}'.format('This is' if start else 'that {}'.format(verb),
        noun,'' if n==0 else '\n'+verse(n-1,False))