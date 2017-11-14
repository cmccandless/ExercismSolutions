from itertools import groupby

BLACK = 'B'
WHITE = 'W'
NONE = ' '


class Board:
    """Count territories of each player in a Go game

    Args:
        board (list[str]): A two-dimensional Go board
    """

    def __init__(self, board):
        self.board = board.split('\n')

    def validPoint(self, x, y):
        return (y >= 0 and y < len(self.board) and
                x >= 0 and x < len(self.board[y]))

    def territoryFor(self, coord):
        """Find the owner and the territories given a coordinate on
           the board

        Args:
            coord ((int,int)): Coordinate on the board

        Returns:
            (str, set): A tuple, the first element being the owner
                        of that area.  One of "W", "B", "".  The
                        second being a set of coordinates, representing
                        the owner's territories.
        """
        x, y = coord
        if not self.validPoint(*coord) or self.board[y][x] != NONE:
            return (NONE, set())
        visited = set()
        to_visit = [coord]
        owner = None
        territory = set()
        while to_visit:
            coord = to_visit.pop(0)
            x, y = coord
            if coord in visited:
                continue
            visited.add(coord)
            if not self.validPoint(*coord):
                continue
            if self.board[y][x] == NONE:
                territory.add(coord)
                for dx, dy in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
                    to_visit.append((x + dx, y + dy))
            else:
                if owner is None:
                    owner = self.board[y][x]
                elif owner != self.board[y][x]:
                    owner = NONE
        if owner is None:
            owner = NONE
        return (owner, territory)

    def territories(self):
        """Find the owners and the territories of the whole board

        Args:
            none

        Returns:
            dict(str, set): A dictionary whose key being the owner
                        , i.e. "W", "B", "".  The value being a set
                        of coordinates owned by the owner.
        """
        points = [(x, y) for y in range(len(self.board))
                  for x in range(len(self.board[y]))]
        all_territories = map(self.territoryFor, points)
        sorted_territories = sorted(all_territories, key=lambda t: t[0])
        by_player = groupby(sorted_territories, lambda t: t[0])
        flattened = {k: {p for _, ps in g for p in ps} for k, g in by_player}
        for player in [BLACK, WHITE, NONE]:
            if player not in flattened:
                flattened[player] = set()
        return flattened
