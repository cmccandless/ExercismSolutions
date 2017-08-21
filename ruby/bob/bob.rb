class Bob
	def self.hey(prompt)
		prompt = prompt.strip
		prompt = case
		when prompt == ''
			"Fine. Be that way!"
		when prompt =~ /[A-Z]/ && prompt.upcase == prompt
			"Whoa, chill out!"
		when prompt[-1] == '?'
			"Sure."
		else
			"Whatever."
		end
	end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end
  