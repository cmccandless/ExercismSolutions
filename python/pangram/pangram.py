alphabet=['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z']

def is_pangram(phrase):
	chars={}
	for ch in phrase.lower():
		try:
			chars[ch]+=1
		except KeyError:
			chars[ch]=1
	return all(ch in chars for ch in alphabet)