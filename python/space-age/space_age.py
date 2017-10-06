EARTH_SECONDS = 31557600
FACTOR = {'earth': 1,
          'mercury': 0.2408467,
          'venus': 0.61519726,
          'mars': 1.8808158,
          'jupiter': 11.862615,
          'saturn': 29.447498,
          'uranus': 84.016846,
          'neptune': 164.79132}


class SpaceAge:
    def __init__(self, seconds):
        self.seconds = seconds

    def __getattribute__(self, name):
        if name.startswith('on_'):
            planet = name[3:]
            if planet in FACTOR:
                def on_planet(seconds=self.seconds):
                    return round(seconds / FACTOR[planet] / EARTH_SECONDS, 2)
                return on_planet
        return object.__getattribute__(self, name)
