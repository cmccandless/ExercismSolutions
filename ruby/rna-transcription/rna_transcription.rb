class Complement
	def self.of_dna(codons)
		if codons == '' || codons =~ /[^CGTA]/
			return ''
		end
		return case codons[0]
		when 'C' 
			'G'
		when 'G'
			'C'
		when 'T'
			'A'
		when 'A'
			'U'
		else
			''
		end + of_dna(codons[1..-1])
	end
end

module BookKeeping
  VERSION = 4 # Where the version number matches the one in the test.
end