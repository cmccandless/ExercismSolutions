def abbreviate(phrase):
    words = ''.join(ch for ch in phrase if ch not in ',')
    words = words.replace('-', ' ').split()
    result = ''
    for word in words:
        result += word.upper()[0]
        if word == word.upper():
            if word.endswith(':'):
                return word[:-1]
        else:
            result += ''.join([ch for ch in word[1:] if ch == ch.upper()])
    return result
