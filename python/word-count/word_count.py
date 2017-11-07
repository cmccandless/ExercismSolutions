import re


def word_count(phrase):
    results = {}
    clean = phrase.lower().replace('_', ' ')
    for match in re.findall("(\w+(?:'\w)?)", clean):
        try:
            results[match] += 1
        except KeyError:
            results[match] = 1
    return results
