def is_pangram(phrase):
    alphabet = set([chr(i) for i in range(ord('a'), ord('z') + 1)])
    chars = set(phrase.lower())
    return alphabet == chars.intersection(alphabet)
