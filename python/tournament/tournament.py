fmt = '{:<31}|{:>3} |{:>3} |{:>3} |{:>3} |{:>3}'


class TeamData:
    def __init__(self, name):
        self.name = name
        self.wins = 0
        self.draws = 0
        self.losses = 0

    def points(self):
        return self.wins * 3 + self.draws

    def games(self):
        return self.wins + self.draws + self.losses

    def __str__(self):
        return fmt.format(self.name,
                          self.games(),
                          self.wins,
                          self.draws,
                          self.losses,
                          self.points())

    def __lt__(self, other):
        return (-self.points(), self.name) < (-other.points(), other.name)

    def add(self, result, ishome=True):
        iswin = (result == 'win') == ishome
        if result == 'draw':
            self.draws += 1
        elif iswin:
            self.wins += 1
        else:
            self.losses += 1


def tally(data):
    teams = {}
    for home, away, result in [game.split(';') for game in
                               data.split('\n')
                               if game != '']:
        teams.setdefault(home, TeamData(home)).add(result)
        teams.setdefault(away, TeamData(away)).add(result, False)
    return '\n'.join([fmt.format('Team', 'MP', 'W', 'D', 'L', 'P')] +
                     list(map(str, sorted(teams.values()))))
