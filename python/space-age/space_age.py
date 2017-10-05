EARTH_SECONDS = 31557600
d = {'Earth': 1,
     'Mercury': 0.2408467,
     'Venus': 0.61519726,
     'Mars': 1.8808158,
     'Jupiter': 11.862615,
     'Saturn': 29.447498,
     'Uranus': 84.016846,
     'Neptune': 164.79132}
for k in d.keys():
    d[k] *= EARTH_SECONDS


class SpaceAge:
    def __init__(self, seconds):
        self.seconds = seconds

    def on_earth(self):
        return round(self.seconds / d['Earth'], 2)

    def on_mercury(self):
        return round(self.seconds / d['Mercury'], 2)

    def on_venus(self):
        return round(self.seconds / d['Venus'], 2)

    def on_mars(self):
        return round(self.seconds / d['Mars'], 2)

    def on_jupiter(self):
        return round(self.seconds / d['Jupiter'], 2)

    def on_saturn(self):
        return round(self.seconds / d['Saturn'], 2)

    def on_uranus(self):
        return round(self.seconds / d['Uranus'], 2)

    def on_neptune(self):
        return round(self.seconds / d['Neptune'], 2)
