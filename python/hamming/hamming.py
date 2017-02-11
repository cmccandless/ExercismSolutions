def distance(x,y):
	return 0 if len(x) != len(y) else sum(x[i] != y[i] for i in range(len(x)))