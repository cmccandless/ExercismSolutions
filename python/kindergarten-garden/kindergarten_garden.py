STUDENTS=['Alice','Bob','Charlie','David',
'Eve','Fred','Ginny','Harriet',
'Ileana','Joseph','Kincaid','Larry']
plantsD={'V':'Violets','R':'Radishes','C':'Clover','G':'Grass'}

class Garden:
	def __init__(self,plants,students=STUDENTS):
		self.plantSets=plants.split('\n')
		self.students=dict([(s,2*i) for i,s in enumerate(sorted(students[:int(len(self.plantSets[0])/2)]))])
	def plants(self,name):
		i=self.students[name]
		return [plantsD[p] for p in 
			''.join([self.plantSets[0][i:i+2],self.plantSets[1][i:i+2]])]