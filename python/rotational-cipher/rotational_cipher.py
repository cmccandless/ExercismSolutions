def rotate(s, n):
    return ''.join((chr((ord(x) + n - a) % 26 + a)
                    if x.isalpha()
                    else x)
                   for x, a in
                   [(x, ord('a') if x.islower() else ord('A')) for x in s])
