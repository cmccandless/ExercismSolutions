fmt = '{:<31}|{:>3} |{:>3} |{:>3} |{:>3} |{:>3}'


class TeamData:
    def __init__(self, name):
        self.name = name
        self.w = 0
        self.d = 0
        self.l = 0

    def points(self):
        return self.w * 3 + self.d

    def games(self):
        return self.w + self.d + self.l

    def __str__(self):
        return fmt.format(self.name,
                          self.games(),
                          self.w,
                          self.d,
                          self.l,
                          self.points())

    def __lt__(self, other):
        return (-self.points(), self.name) < (-other.points(), other.name)

    def add(self, result, ishome=True):
        iswin = (result == 'win') == ishome
        if result == 'draw':
            self.d += 1
        elif iswin:
            self.w += 1
        else:
            self.l += 1


def tally(data):
    teams = {}
    for home, away, result in [l.split(';') for l in
                               data.split('\n')
                               if l != '']:
        teams.setdefault(home, TeamData(home)).add(result)
        teams.setdefault(away, TeamData(away)).add(result, False)
    return '\n'.join([fmt.format('Team', 'MP', 'W', 'D', 'L', 'P')] +
                     list(map(str, sorted(teams.values()))))
