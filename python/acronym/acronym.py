def abbreviate(phrase):
	words = ''.join(ch for ch in phrase if not ch in ':,').replace('-',' ').split()
	result=''
	for word in words:
		if word==word.upper(): return word
		result+=word.upper()[0]
		result+=''.join([ch for ch in word[1:] if ch==ch.upper()])
	return result