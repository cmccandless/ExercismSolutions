rep = {'G': 'C', 'C': 'G', 'T': 'A', 'A': 'U'}


def to_rna(seq):
    return ''.join([rep[ch] for ch in seq])
