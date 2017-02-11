from random import randint,seed
from time import clock
def rndChr():
	return chr(randint(ord('A'),ord('Z')))
def rndName():
	return '{}{}{:03}'.format(rndChr(),rndChr(),randint(0,999))
class Robot:
	def __init__(self):
		seed(clock())
		self.name=rndName()
	def reset(self):
		seed(clock())
		self.name=rndName()