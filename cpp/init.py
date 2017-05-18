from os import popen, getcwd, chdir, mkdir, sep, path
from sys import argv
import re

if __name__ == '__main__':
	pattern = r'Not Submitted: \d problems?\s*cpp \([\w\s]+\) (?:c:)?(\\|/)(?:[a-z\d\s]+\1)*([a-z\-]+)\s*\r?\n'
	p = re.compile('(?i)' + pattern)
	out = popen('exercism f cpp').read()
	m = p.search(out)
	exercise = m.group(2)
	# exercise = argv[1]
	chdir(exercise)
	with open('{}.h'.format(exercise), 'w') as f:
		f.write('#ifndef {0}_h\n#define {0}_h\n\n\n#endif\n'.format(exercise))
	with open('{}.cpp'.format(exercise), 'w') as f:
		f.write('#include "{}.h"\n\n'.format(exercise))
	if not path.exists('build'): mkdir('build')
	chdir('build')
	print(popen('cmake -G "Visual Studio 14" -DBOOST_INCLUDEDIR=C:\local\boost_1_64_0 ..').read())
