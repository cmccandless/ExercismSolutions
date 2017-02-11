from functools import reduce

def largest_product(s,n):
	if n < 0 or (s == '' and n > 0) or n > len(s): raise ValueError()
	return 1 if s == '' or n ==0 else sorted([reduce(lambda x,y: int(x)*int(y), 
		s[i:i+n]) for i in range(0,len(s)-n+1)])[-1]