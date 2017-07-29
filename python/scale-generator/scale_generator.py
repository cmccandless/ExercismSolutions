majorKeys = ['A','A#','B','C','C#','D','D#','E','F','F#','G','G#']
minorKeys = ['A','Bb','B','C','Db','D','Eb','E','F','Gb','G','Ab']
validMajorTonics = set(['A','a','B','b','C','c#','D','d#','E','e','F#','f#','G','g#'])
step = { 'm': 1, 'M': 2, 'A': 3 }

class Scale(object):
    def __init__(self, tonic, type, intervals = 'mmmmmmmmmmmm'):
        self.tonic = tonic
        self.type = type
        keys = majorKeys if tonic in validMajorTonics else minorKeys
        t = tonic[0].upper() + tonic[1:]
        self.name = '{} {}'.format(t, type)
        i = keys.index(t)
        self.pitches = [keys[i]]
        for interval in intervals[:-1]:
            i += step[interval]
            self.pitches.append(keys[i % len(keys)])