codons ={ 'AUG': 'Methionine',
  'UGG': 'Tryptophan',
  'UGU': 'Cysteine',
  'UGC': 'Cysteine',
  'UCU': 'Serine',
  'UCC': 'Serine',
  'UCA': 'Serine',
  'UCG': 'Serine',
  'UAU': 'Tyrosine',
  'UAC': 'Tyrosine',
  'UUA': 'Leucine',
  'UUG': 'Leucine',
  'UUC': 'Phenylalanine',
  'UUU': 'Phenylalanine',
  'UAA': 'STOP',
  'UAG': 'STOP',
  'UGA': 'STOP',
}

def of_codon(codon):
  try: return codons[codon]
  except KeyError: raise ValueError()


def of_rna(rna):
  result = []
  while len(rna) > 2:
    x = of_codon(rna[:3])
    if x == 'STOP': break
    result.append(x)
    rna = rna[3:]
  return result