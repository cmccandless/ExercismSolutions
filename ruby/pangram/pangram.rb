class Pangram
	def self.letter?(c)
		c =~ /[[:alpha:]]/
	end
	def self.pangram?(phrase)
		unique = phrase.downcase.chars.uniq!
		if unique.nil?
			phrase = false
		else
			phrase = unique.select{|c| letter?(c)}.length == 26
		end
	end
end
module BookKeeping
  VERSION = 4 # Where the version number matches the one in the test.
end