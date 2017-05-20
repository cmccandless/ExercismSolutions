from os import popen, getcwd, chdir, mkdir, sep, path
from sys import argv, exit
import re

if __name__ == '__main__':
	pattern = r'Not Submitted:\s+\d problems?\s*cpp \([\w\s]+\) (?:c:)?(\\|/)(?:[a-z\d\s]+\1)*([a-z\-]+)\s*\r?\n'
	p = re.compile('(?i)' + pattern)
	out = popen('exercism f cpp').read()
	m = p.search(out)
	if m is None:
		print(out)
		print('Match failure; not initialized.')
		exit(1)
	exercise = m.group(2)
	chdir(exercise)
	exercise = exercise.replace('-','_')
	with open('{}.h'.format(exercise), 'w') as f:
		f.write('#ifndef {0}_h\n#define {0}_h\n\n\n\n#endif\n'.format(exercise))
	with open('{}.cpp'.format(exercise), 'w') as f:
		f.write('#include "{}.h"\n\n'.format(exercise))
	if not path.exists('build'): mkdir('build')
	chdir('build')
	print(popen('cmake -Wno-dev -G "Visual Studio 14" -DBOOST_INCLUDEDIR=C:\local\boost_1_64_0 ..').read())

	
# Not Submitted:   1 problem
# cpp (Word Count) C:\A Corey\Documents\Git\ExercismSolutions\cpp\word-count

# unchanged: 1, updated: 0, new: 0
