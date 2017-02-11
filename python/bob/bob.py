#
# Skeleton file for the Python "Bob" exercise.
#
import re
def hey(what):
	what=what.strip()
	if what == '': return 'Fine. Be that way!'
	elif re.match('(?i).*[a-z]',what) and what.upper()==what: return 'Whoa, chill out!'
	elif what[-1]=='?': return 'Sure.'
	return 'Whatever.'
