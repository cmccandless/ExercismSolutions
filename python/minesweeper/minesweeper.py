valid = set('+-* |')


def countMines(x, y, board):
    xmin, xmax = (max(0, x - 1), min(x + 2, len(board[y])))
    ymin, ymax = (max(0, y - 1), min(y + 2, len(board)))
    result = [c for r in board[ymin:ymax]
              for c in r[xmin:xmax]
              if c == '*']
    return len(result) if len(result) > 0 else ' '


def board(inp):
    for i, r in enumerate(inp):
        if len(r) != len(inp[0]):
            raise ValueError(
                'row {} length does not match length of first row'.format(i)
            )
        for c in r:
            if c not in valid:
                raise ValueError('invalid character ' + c)
    b = [list(r) for r in inp]
    b = [''.join([c if c != ' ' else str(countMines(x, y, b))
                  for x, c in enumerate(r)])
         for y, r in enumerate(b)]
    return b
