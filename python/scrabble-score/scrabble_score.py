scores = {'M': 3, 'N': 1, 'L': 1, 'U': 1, 'F': 4, 'R': 1, 'A': 1,
          'W': 4, 'O': 1, 'D': 2, 'V': 4, 'Z': 10, 'P': 3, 'E': 1,
          'B': 3, 'T': 1, 'S': 1, 'J': 8, 'C': 3, 'Q': 10, 'H': 4,
          'G': 2, 'K': 5, 'Y': 4, 'X': 8, 'I': 1}


def score(word):
    if (word == '' or any(not ch.isalpha() for ch in word)):
        return 0
    return sum(map(scores.get, word.upper()))
