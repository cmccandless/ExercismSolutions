def transpose(s):
	results = []
	lines = s.split('\n')
	m = max(len(line) for line in lines)
	for line in lines:
		c = 0
		for i in range(m):
			while True:
				try:
					results[c] += line[i] if i < len(line) else ' '
					break
				except IndexError:
					results.append('')
			c += 1
	return '\n'.join(results).rstrip()
