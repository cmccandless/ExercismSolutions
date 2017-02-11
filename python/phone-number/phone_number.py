class Phone:
    def __init__(self,str):
        str=''.join([x for x in str if x in '0123456789'])
        if len(str)==10: self.number=str
        elif len(str)==11 and str[0]=='1': self.number=str[1:]
        else: self.number='0'*10
    def area_code(self):
        return self.number[:3]
    def pretty(self):
        return '({}) {}-{}'.format(self.area_code(),
            self.number[3:6],self.number[-4:])