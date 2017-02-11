NORTH=0
EAST=1
SOUTH=2
WEST=3

class Robot:
	def __init__(self,bearing=NORTH,x=0,y=0):
		self.coordinates=(x,y)
		self.bearing=bearing
	def turn_right(self):
		self.bearing += 1
		self.bearing %= 4
	def turn_left(self):
		self.bearing += 3
		self.bearing %= 4
	def advance(self):
		x,y=self.coordinates
		if self.bearing==NORTH: self.coordinates=(x,y+1)
		elif self.bearing==SOUTH: self.coordinates=(x,y-1)
		elif self.bearing==EAST: self.coordinates=(x+1,y)
		else: self.coordinates=(x-1,y)
	def simulate(self,commands):
		for ch in commands:
			if ch=='L': self.turn_left()
			elif ch=='R': self.turn_right()
			elif ch=='A': self.advance()
