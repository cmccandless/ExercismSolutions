from random import randint
a=97
z=122

class Caesar:
	def encode(self,decoded):
		return ''.join([chr(((ord(x) - 94) % 26) + a)
			for x in decoded.lower() if ord(x) <= z and ord(x) >= a])
	def decode(self,encoded):
		return ''.join([chr(((ord(x) - 74) % 26) + a) for x in encoded])
	
class Cipher:
	def __init__(self,key=None):
		if key==None: 
			key=''.join([chr(randint(a, z)) for _ in range(100)])
		elif any([ord(x) > z or ord(x) < a for x in key]): 
			raise ValueError()
		self.key=key
	def encode(self,decoded):
		return ''.join([chr(((ord(x) - 2 * a + 
			ord(self.key[i % len(self.key)])) % 26) + a)
			for i, x in enumerate(decoded.lower()) 
			if ord(x) <= z and ord(x) >= a])
	def decode(self,encoded):
		return ''.join([chr(((ord(x) + 26 - 
			ord(self.key[i%len(self.key)])) % 26) + a) 
			for i, x in enumerate(encoded)])
		
	