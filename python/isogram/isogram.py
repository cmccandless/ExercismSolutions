z = ord('z')
a = ord('a')


def is_isogram(s):
    s = [x for x in s.lower() if ord(x) <= z and ord(x) >= a]
    return len(s) == len(set(s))
