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
            return pitches + [key]
        return reduce(
            doStep,
            map('_mMA'.index, intervals),
            [tonic.title()]
        )

    def __init__(self, tonic, intervals='mmmmmmmmmmmm'):
        self.pitches = Scale.pitches(tonic, intervals)
        if self.pitches[0] != self.pitches[-1]:
            raise ValueError('broken interval')
        self.pitches = self.pitches[:-1]
