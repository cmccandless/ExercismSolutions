class Hamming
	def self.compute(a, b)
		if a.length != b.length
			raise(ArgumentError)
		end
		if a == ""
			return 0
		end
		if a[0] == b[0]
			return compute(a[1..-1], b[1..-1])
		else
			return 1 + compute(a[1..-1], b[1..-1])
		end
	end
end

module BookKeeping
VERSION = 3 # Where the version number matches the one in the test.
end