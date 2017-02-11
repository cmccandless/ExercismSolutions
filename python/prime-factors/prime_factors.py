from math import sqrt

def primesUnder(n):
	if n < 2: return []
	p=[True for _ in range(n)]
	p[0]=p[1]=False
	for i in range(2,n):
		if not p[i]: continue
		yield i
		for j in range(2*i,n,i):
			p[j]=False
	
def prime_factors(n,p=None):
	if p==None:p=set(primesUnder(int(sqrt(n)+1.5)))
	if n < 2: return []
	elif n in p: return [n]
	for x in p:
		if n%x==0: return [x] + prime_factors(n/x,p)
	return [n]
	