from os import popen
from sys import argv
import re

if __name__ == '__main__':
	pattern = r'(?i)recently submitted exercise:\s*-\s*([a-z\-]+)'
	p = re.compile(pattern)
	out = popen('exercism st cpp').read()
	m = p.search(out)
	if m is None:
		print(out)
		print('Match failed.')
		exit(1)
	prev = m.group(1)
	current = popen('getNext.cmd {}'.format(prev)).read()[:-1]
	cmd = 'exercism s {0}\{1}.cpp {0}\{1}.h'.format(current, current.replace('-','_'))
	print(cmd + '\n')
	print(popen(cmd).read())