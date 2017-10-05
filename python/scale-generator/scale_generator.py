from functools import reduce


class Scale:
    @staticmethod
    def keys(tonic):
        if tonic in 'ABCDEGabe' or (tonic[-1] == '#' and tonic[0] in 'Fcdfg'):
            return ['A', 'A#', 'B', 'C', 'C#', 'D',
                    'D#', 'E', 'F', 'F#', 'G', 'G#']
        return ['A', 'Bb', 'B', 'C', 'Db', 'D',
                'Eb', 'E', 'F', 'Gb', 'G', 'Ab']

    @staticmethod
    def pitches(tonic, intervals):
        keys = Scale.keys(tonic)

        def doStep(pitches, step):
            key = keys[(keys.index(pitches[-1]) + step) % len(keys)]
            pitches.append(key)
            return pitches
        return reduce(doStep,
                      map('_mMA'.index, intervals),
                      [tonic.title()])

    def __init__(self, tonic, name, intervals='mmmmmmmmmmmm'):
        self.name = '{} {}'.format(tonic.title(), name)
        self.pitches = Scale.pitches(tonic, intervals[:-1])
