class BowlingGame(object):
    def __init__(self):
        self.frames = [[]]

    def complete(self):
        if len(self.frames) < 10:
            return False
        if self.frames[9][0] == 10:  # Strike in frame 10
            if len(self.frames) < 11:
                return False
            if self.frames[10][0] == 10:
                return len(self.frames) == 12
            return len(self.frames[10]) == 2
        if sum(self.frames[9]) == 10:  # Spare in frame 10
            return len(self.frames) == 11
        return len(self.frames[9]) == 2

    def roll(self, pins):
        if pins < 0 or pins > 10:
            raise ValueError('pin count must be between 0 and 10')
        if self.complete():
            raise IndexError('cannot roll on complete game')
        if (
            (
                len(self.frames[-1]) == 1 and
                self.frames[-1][0] == 10  # Strike in previous frame
            ) or
            len(self.frames[-1]) == 2  # Previous frame already complete
        ):
            self.frames.append([])
        self.frames[-1].append(pins)
        if sum(self.frames[-1]) > 10:
            raise ValueError('frame pin count cannot be greater than 10')

    def score(self):
        for i in range(10):
            if self.frames[i][0] == 10:  # Strike in frame i
                self.frames[i][0] += sum(self.frames[i + 1])
                if self.frames[i + 1][0] == 10:  # Strike in frame after i
                    self.frames[i][0] += self.frames[i + 2][0]
            elif sum(self.frames[i]) == 10:  # Spare in frame i
                self.frames[i][0] += self.frames[i + 1][0]
        return sum(map(sum, self.frames[:10]))
