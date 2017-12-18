class Luhn:
    def __init__(self, number):
        self.number = number.replace(' ', '')
        try:
            terms = [(len(str(self.number)) - i - 1, int(x)) for
                     i, x in enumerate(str(self.number))]
            terms = [x if i % 2 == 0 else 2 * x for i, x in terms]
            self.__addends__ = [x if x < 10 else x - 9 for x in terms]
            self._checksum = sum(self.__addends__)
            self.valid = self.number != '0'
        except ValueError:
            self.valid = False

    def addends(self):
        return self.__addends__

    def checksum(self):
        return self._checksum

    def is_valid(self):
        return self.valid and self.checksum() % 10 == 0

    @staticmethod
    def create(n):
        new = Luhn(n * 10)
        digit = 0
        while not new.is_valid():
            digit += 1
            new = Luhn(n * 10 + digit)
        return new.number
