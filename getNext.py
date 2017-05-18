from os import path, getcwd, sep, popen
from sys import argv, exit

def printUsage():
	print('Usage:')
	print('    From exercise directory: getNext.py')
	print('    From track directory: getNext.py <exercise>')
	print('    From root directory: getNext.py <track> <exercise>')
	
if __name__ == '__main__':
	cwd = getcwd()
	parts = cwd.split(sep)
	exercise = parts[-1]
	track = parts[-2]
	if track == 'ExercismSolutions':
		track = exercise
		if len(argv) < 2:
			printUsage()
			exit(1)
		exercise = argv[1]
		cwd = path.join(cwd,exercise)
	elif exercise == 'ExercismSolutions':
		if len(argv) < 3:
			if len(argv) == 2 and path.isdir(argv[1]):
				track,exercise = argv[1].split(sep)
			else:
				printUsage()
				exit(1)
		else:
			track = argv[1]
			exercise = argv[2]
		cwd = path.join(cwd,track,exercise)
	# print('Track: {}'.format(track))
	# print('Exercise: {}'.format(exercise))
	# print(cwd)
	cmd = 'powershell -Command "& exercism li {} | sls -patt "^{}$" -co 0,1"'.format(track, exercise)
	proc = popen(cmd)
	output = proc.readlines()
	print(output[-3].strip())
	# print('\n'.join(output))