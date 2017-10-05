from random import randint, seed
from time import clock


def rndChr():
    return chr(randint(ord('A'), ord('Z')))


class Robot:
    def __init__(self):
        seed(clock())
        self.name = None
        self.reset()

    def reset(self):
        seed(clock())
        self.name = '{}{}{:03}'.format(rndChr(), rndChr(), randint(0, 999))
