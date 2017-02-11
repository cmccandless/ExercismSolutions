def prefix(word):
	if not any([word.startswith(x) for x in ['xr','yt']]):
		for x in ['sch','squ','thr','qu','th','sc','sh','ch','st','b',
		'c','d','f','g','h','j','k','l','m','n','p','q','r','s','t',
		'v','w','x','y','z']:
			if word.startswith(x): return x
	return ''

def translate(phrase):
	return ' '.join([x[0] for i,x in enumerate([(x[len(y):]+y+'ay',x) 
		for x,y in [(x,prefix(x)) for x in phrase.split()]])])