
class ConnectGame:
    def __init__(self, board):
        self.board = board.replace(' ', '').split('\n')

    def get_winner(self):
        print(self.board)
        visited = set()
        to_visit = []
        directions = [(-1, 0), (0, -1), (1, -1),
                      (1, 0), (0, 1), (-1, 1)]
        for y in range(len(self.board)):
            to_visit.append((0, y, 'X'))
        for x in range(len(self.board[0])):
            to_visit.append((x, 0, 'O'))
        while to_visit:
            tup = to_visit.pop(0)
            if tup in visited:
                continue
            visited.add(tup)
            x, y, token = tup
            if y < 0 or y >= len(self.board):
                continue
            if x < 0 or x >= len(self.board[y]):
                continue
            if self.board[y][x] != token:
                continue
            if token == 'X' and x == len(self.board[0]) - 1:
                return token
            elif token == 'O' and y == len(self.board) - 1:
                return token
            for dx, dy in directions:
                to_visit.append((x + dx, y + dy, token))
        return ''
