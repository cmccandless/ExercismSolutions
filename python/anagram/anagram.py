def isAnagram(base,baseS,word):
	return base != word and sorted(word)==baseS

def detect_anagrams(base,words):
	baseL = base.lower()
	baseS=sorted(baseL)
	wordsL=[(x,x.lower()) for x in words]
	return [x for x,y in wordsL if baseL!=y and sorted(y)==baseS]