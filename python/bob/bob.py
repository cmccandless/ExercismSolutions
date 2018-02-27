import re


def hey(what):
    what = what.strip()
    is_yelling = re.match('(?i).*[a-z]', what) and what.upper() == what
    is_asking = what and what[-1] == '?'
    if what == '':
        return 'Fine. Be that way!'
    elif is_yelling:
        if is_asking:
            return "Calm down, I know what I'm doing!"
        return 'Whoa, chill out!'
    elif is_asking:
        return 'Sure.'
    return 'Whatever.'
