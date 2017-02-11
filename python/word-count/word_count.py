# -*- coding: utf-8 -*-
import re
p=re.compile('[\s_]')
def word_count(phrase):
	phrase=phrase.lower()
	phrase = re.sub('\W',' ',phrase)
	result={}
	print(phrase)
	for word in p.split(phrase):
		if word == '': continue
		try:
			result[word]+=1
		except KeyError:
			result[word]=1
	print(result)
	return result