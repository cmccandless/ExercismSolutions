class Phone:
    def __init__(self, str):
        str = ''.join([x for x in str if x in '0123456789'])
        if len(str) == 10:
            self.number = str
        elif len(str) == 11 and str[0] == '1':
            self.number = str[1:]
        else:
            raise ValueError('bad format')
        self.area_code = self.number[:3]
        if self.area_code[:1] in '01':
            raise ValueError('bad area code')
        self.exchange_code = self.number[3:6]
        if self.exchange_code[:1] in '01':
            raise ValueError('bad exchange code')

    def pretty(self):
        return '({}) {}-{}'.format(self.area_code,
                                   self.exchange_code,
                                   self.number[-4:])
