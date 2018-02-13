def verify(isbn):
    total = 0
    index = 10
    isbn = list(isbn.replace('-', ''))
    while isbn:
        ch = isbn.pop(0)
        if index == 1 and ch == 'X':
            total += 10
        elif ch in '0123456789':
            total += index * int(ch)
        else:
            return False
        index -= 1
    return total != 0 and total % 11 == 0
