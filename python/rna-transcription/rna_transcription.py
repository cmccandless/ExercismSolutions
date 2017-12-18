rep = {'G': 'C', 'C': 'G', 'T': 'A', 'A': 'U'}


def to_rna(seq):
    try:
        return ''.join([rep[ch] for ch in seq])
    except KeyError as e:
        raise ValueError('invalid nucleotide ' + str(e))
