z=ord('z')
a=ord('a')

def encode(str):
	return ''.join(['{}{}'.format('' if i==0 or (i % 5)!=0 else ' ',
		ch if o < a else chr(z+a-o)) 
		for i,ch,o in [(j,c,ord(c)) 
		for j,c in enumerate([x for x in str.lower() if not x in ' .,'])]])

def decode(str):
	return ''.join([ch if o < a else chr(z+a-o) 
		for i,ch,o in [(j,c,ord(c)) 
		for j,c in enumerate(str) if c != ' ']])
