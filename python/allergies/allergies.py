a={'eggs':1,
'peanuts':2,
'shellfish':4,
'strawberries':8,
'tomatoes':16,
'chocolate':32,
'pollen':64,
'cats':128}

class Allergies:
	def __init__(self,i):
		self.lst=[k for k,v in a.items() if i & v > 0]
	def is_allergic_to(self,allergen):
		return allergen in self.lst