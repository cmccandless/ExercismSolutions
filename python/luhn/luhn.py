class Luhn:
	def __init__(self,n):
		self.n=n
		self._addends=[x if x < 10 else x-9 
			for x in [x if i%2==0 else 2*x 
			for i,x in [(len(str(n))-i-1,int(x)) for i,x in enumerate(str(n))]]]
		self._checksum=sum(self._addends)
	def addends(self):
		return self._addends
	def checksum(self):
		return self._checksum
	def is_valid(self):
		return self.checksum()%10==0
	@staticmethod
	def create(n):
		l=Luhn(n*10)
		digit=0
		while not l.is_valid(): 
			digit+=1
			l=Luhn(n*10+digit)
		return l.n