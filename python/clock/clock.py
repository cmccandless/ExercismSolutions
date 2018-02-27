class Clock:
    def __init__(self, hour, minute):
        self.hour = hour % 24
        self.minute = 0
        self.__add__(minute)

    def __add__(self, minutes):
        self.minute += minutes
        while self.minute > 59:
            self.minute -= 60
            self.hour += 1
        while self.minute < 0:
            self.minute += 60
            self.hour -= 1
        self.hour %= 24
        return self

    def __sub__(self, minutes):
        return self + -minutes

    def __str__(self):
        return '{:02}:{:02}'.format(self.hour, self.minute)

    def __eq__(self, other):
        return self.hour == other.hour and self.minute == other.minute
