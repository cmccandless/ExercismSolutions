class Phrase
	def initialize(phrase)
		@phrase = phrase
	end
	def word_count
		result = Hash.new(0)
		@phrase.downcase.scan(/\w+(?:'t)?/) { |word| result[word] += 1 if word != '' }
		return result
	end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end